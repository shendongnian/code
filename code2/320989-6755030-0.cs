    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                List<string> css = new List<string>
                {
                    ".header {font-size:14px;}",
                    ".foo"
                };
                List<string> usedCss = new List<string>
                {
                    ".header",
                    ".foo",
                    ".foobar"
                };
                List<string> list = usedCss.Where(u => css.Any(c => c.Contains(u)))
                    .ToList();
                if (list.Count > 0)
                {
                    Console.WriteLine("Has found:");
                    list.ForEach(Console.WriteLine);
                }
                else
                {
                    usedCss.ForEach(x => Console.WriteLine("Could not find: " + x));
                }
                Console.ReadKey();
            }
        }
    }
