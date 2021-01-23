    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    //...
    public static void TestStringSplit()
    {
        var s = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.";
        var chars = s.ToCharArray().AsEnumerable();
        var pages = new List<int>() { 8, 4, 5, 3, 50, 50 };
        var output = new List<string>();
        for (int i = 0; i < pages.Count; i++)
        {
            var page = pages[i];
            output.Add(String.Join("",
                chars.Skip(pages.Where((p, j) => j < i).Sum(p => p)).Take(page)
                ));
        }
        output.ForEach(o => Console.WriteLine(o));
    }
