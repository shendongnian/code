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
                    for (int i = 0; i < 3; i++)  // Three dates in file
                    {
                        b = reader.ReadBytes(b.Length);
                        Console.WriteLine("Bytes: {0}, {1}, {2}", b[0].ToString("X2"), b[1].ToString("X2"), b[2].ToString("X2"));
                        int n = ((b[0] << 16) + (b[1] << 8) + b[2]);
                        s = n.ToString("D6");
                        switch (i)
                        {
                            case 0:
                            case 2:
                                Console.WriteLine("Date(YYMMDD): {0}", s);
                                d = DateTime.ParseExact(s, "yyMMdd", CultureInfo.InvariantCulture);
                                Console.WriteLine("Date(yyyyMMdd): {0}", d.ToString("yyyyMMdd"));
                                break;
                            case 1:
                                Console.WriteLine("Date(DDMMYY): {0}", s);
                                d = DateTime.ParseExact(s, "ddMMyy", CultureInfo.InvariantCulture);
                                Console.WriteLine("Date(yyyyMMdd): {0}", d.ToString("yyyyMMdd"));
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
