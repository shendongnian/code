    using System;
    using System.Globalization;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] b = { 0, 0, 0 };
                string s;
                DateTime d = new DateTime();
                using (BinaryReader reader = new BinaryReader(File.Open(@"y:\dates.dat", FileMode.Open)/*, Encoding.Default*/))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 3)
                        {
                            Console.WriteLine(" ");
                        }
                        b = reader.ReadBytes(3);
                        Console.WriteLine("Bytes: 0x{0}, 0x{1}, 0x{2}", b[0].ToString("x2"), b[1].ToString("x2"), b[2].ToString("x2"));
                        int n = ((b[0] << 16) + (b[1] << 8) + b[2]);
                        if (i < 3)
                        {
                            s = n.ToString("D6");
                            Console.WriteLine("Date(YYMMDD): {0}", s);
                            d = DateTime.ParseExact(s, "yyMMdd", CultureInfo.InvariantCulture);
                            Console.WriteLine("Date(yyyyMMdd): {0}", d.ToString("yyyyMMdd"));
                        }
                        else
                        {
                            s = n.ToString("D8");
                            Console.WriteLine("Days since 16001231: {0}", n);
                            DateTime dt = new DateTime(1600, 12, 31);
                            dt = dt.AddDays(n);
                            Console.WriteLine("Date(yyyyMMdd): {0}", dt.ToString("yyyyMMdd"));
                        }
                    }
                }
            }
        }
    }
