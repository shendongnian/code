    using System;
    using System.IO;
    
    namespace ConsoleApp26
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fStream = File.OpenRead(@"C:\TEMP\test.xml");
                var reader = new StreamReader(fStream);
                var i = 0;
                while (!reader.EndOfStream)
                {
    
                    var line = reader.ReadLine();
                    i++;
                    Console.WriteLine(
                        $"Line number {i}.Line contents {line}. Reader position is {reader.BaseStream.Position}/{reader.BaseStream.Length}");
    
                }
    
                Console.ReadLine();
            }
        }
    }
