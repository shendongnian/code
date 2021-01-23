    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var myClass = new[]
            {
                new { Type="first", Title="A" },
                new { Type="second", Title="D" },
                new { Type="first", Title="C" },
                new { Type="second", Title="B" },
            }.ToList();
            var first = myClass.Where(x => x.Type == "first")
                               .ToList();
            var second = myClass.Where(x => x.Type == "second")
                                .ToList();
    
            first.Sort((x, y) => string.Compare(x.Title, y.Title));
            second.Sort((x, y) => string.Compare(x.Title, y.Title));
            myClass.Clear();
            myClass.AddRange(first);
            myClass.AddRange(second);
            foreach (var x in myClass)
            {
                Console.WriteLine(x);
            }
        }
    }
