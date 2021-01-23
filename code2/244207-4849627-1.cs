    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var sha = new SHA256Managed())
                {
                    using (var stream = new MemoryStream(
                        Encoding.ASCII.GetBytes("Hello World!")))
                    {
                        var hash = sha.ComputeHash(stream);
                        var result = Encoding.Default.GetString(hash);
    
                        //print out each byte as hexa in consecutive manner
                        foreach (var h in hash)
                        {
                            Console.Write("{0:x2}", h);
                        }
                        Console.WriteLine();
                        //Show the resulting string from GetString
                        Console.WriteLine(result);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
