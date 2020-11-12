using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _232323
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static string Perevod (string n)
        {
            string y = "";
            switch (n)
            {
                case "0000":
                    y = "0";
                    break;
                case "0001":
                    y = "1";
                    break;
                case "0010":
                    y = "2";
                    break;
                case "0011":
                    y = "3";
                    break;
                case "0100":
                    y = "4";
                    break;
                case "0101":
                    y = "5";
                    break;
                case "0110":
                    y = "6";
                    break;
                case "0111":
                    y = "7";
                    break;
                case "1000":
                    y = "8";
                    break;
                case "1001":
                    y = "9";
                    break;
                case "1010":
                    y = "A";
                    break;
                case "1011":
                    y = "B";
                    break;
                case "1100":
                    y = "C";
                    break;
                case "1101":
                    y = "D";
                    break;
                case "1110":
                    y = "E";
                    break;
                case "1111":
                    y = "F";
                    break;
                default:
                    y = "Что за числа?";
                    break;
            }
            return y;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string count = countBox.Text.ToString();
            int a = 0;
            int b = 0;
            string x = "";
            string c = "";
            string d = "";
            string cr = "";
            string dr = "";



            for ( int i = 0; i < count.Length; i++)
            { 
                if (count[i].ToString() == "." || count[i].ToString() == ",")
                {
                    if (i == 0)
                    {
                        resultBox.Text = "Нет целой части?";
                        goto dyrak;
                    }
                    a = (4 - (i % 4)) % 4;
                    b = (4 - ((count.Length - i - 1) % 4)) % 4;
                    x = new string('0', a) + count + new string('0', b);
                    for (int j = 0; j < i + a; j++)
                    {
                        c += x[j];
                        if (j%4 == 3 && j!=0)
                        {
                            if (Perevod(c).Length > 1)
                            {
                                resultBox.Text = Perevod(c);
                                goto dyrak;
                            }
                            cr += Perevod(c);
                            c = "";

                        }                      
                    }
                    for (int k = i + a + 1; k < x.Length; k++)
                    {
                        d += x[k];
                        if (k%4 == 0)
                        {
                            if (Perevod(d).Length > 1)
                            {
                                resultBox.Text = Perevod(d);
                                goto dyrak;
                            }
                            dr += Perevod(d);
                            d = "";
                        }
                    }
                    break;
                }
            }
            resultBox.Text = $"{cr}.{dr}";
            dyrak: return;
        }
    }
}
