    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace StreamTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stream = new EnumeratorStream(Generate("x","y","z"), null);
                var buffer = new byte[256];
                int read;
                while ((read = stream.Read(buffer,0,256)) > 0)
                {
                    string s = stream.Encoding.GetString(buffer, 0, read);
                    Console.Write(s);
                }
                Console.ReadLine();
            }
            public static IEnumerable<string> Generate(string d1, string d2, string d3)
            {
                yield return "<myElement>";
                yield return "<myOtherElement1>";
                yield return d1;
                yield return "</myOtherElement1>";
                yield return "<myOtherElement2>";
                yield return d2;
                yield return "</myOtherElement2>";
                yield return "<myOtherElement3>";
                yield return d3;
                yield return "</myOtherElement3>";
                yield return "</myElement>";
            }
        }
    }
