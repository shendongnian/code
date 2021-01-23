    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace stackoverflow.com_questions_5826306_c_linq_question
    {
        public class Program
        {
            public static void Main()
            {
                string fileData = @"
    Name: Name-1
    Contact: Xpto
    Product: Abc
    Quantity: 12
    
    Name: Name-2
    Product: Xyz
    Contact: Acme
    Quantity: 16
    
    Name: Name-3
    Product: aammndh
    Contact: YKAHHYTE
    Quantity: 2
    ";
                string[] lines = fileData.Replace("\r\n", "\n").Split('\n');
                var result = Find(lines, "contact", "acme");
                foreach (var item in result)
                    Console.WriteLine(item);
                Console.WriteLine("");
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
    
            private static string[] Find(string[] lines, string searchField, string searchValue)
            {
                var result = from h4 in
                                 from g4 in
                                     from i in (0).To(lines.Length)
                                     select ((from l in lines select l).Skip(i).Take(4))
                                 where !g4.Contains("")
                                 select g4
                             where h4.Any(
                                 x => x.Split(new char[] { ':' }, 2)[0].Equals(searchField, StringComparison.OrdinalIgnoreCase)
                                     && x.Split(new char[] { ':' }, 2)[1].Trim().Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                             select h4;
                var list = result.FirstOrDefault();
                return list.ToArray();
            }
        }
        public static class NumberExtensions
        {
            public static IEnumerable<int> To(this int start, int end)
            {
                for (int it = start; it < end; it++)
                    yield return it;
            }
        }
    }
