    using System.IO;
    using System.Windows.Forms;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (StreamReader sr = new StreamReader(@"file.csv"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string strline = sr.ReadLine();
                        string[] values = strline.Split(',');
                        if (values.Length >= 6 && values[0].Trim().Length > 0)
                        {
                            MessageBox.Show(values[1]);
                        }
                    }
                }
            }
        }
    }
