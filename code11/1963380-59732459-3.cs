    using System;
    using System.Diagnostics;
    using System.IO;
    namespace Demo
    {
        public class Program
        {
            public static void Main()
            {
                string filename = @"e:\tmp\test.bin";
                File.WriteAllBytes(filename, new byte[0]); // Create empty file.
                var sw = Stopwatch.StartNew();
                using (var file = File.Open(filename, FileMode.Open))
                {
                    file.SetLength(1024*1024*1024);
                }
                Console.WriteLine(sw.Elapsed);
            }
        }
    }
