    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                long lastCode = 28110000;
                int padSize = (lastCode == 0) ? 1 : (int)Math.Log10(lastCode) + 1;
                String filename = @"C:\Documents and Settings\All Users\Desktop\" + lastCode + "_sequentialCodes.txt";
                StreamWriter writer = new StreamWriter(filename, false, Encoding.ASCII);
                writer.AutoFlush = true;
                for (int i = 1; i < lastCode + 1; i++)
                {
                    writer.WriteLine(i.ToString().PadLeft(padSize, '0'));
                    if (i % 100 == 0)
                    {
                        Console.WriteLine(i.ToString());
                    }
                }
                writer.Close();
                Console.WriteLine();
                Console.WriteLine(lastCode + " codes written to \n" + filename);
                Console.Read();
            }
        }
    }
