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
                    ".foo {dfsfd}",
                    ".foobar",
                    ".wefw"
                };
                List<string> usedCss = new List<string>
                {
                    ".header",
                    ".foo",
                };
                List<string> list = css.Where(c => usedCss.Any(c.Contains)).ToList();
                if (list.Count > 0)
                {
                    Console.WriteLine("Has found in:");
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
