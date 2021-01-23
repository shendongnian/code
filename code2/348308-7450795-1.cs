    using System.Linq;
    using System.Collections.Generic;
    ...
    static void Main ( string[] args)
    {
        int[] list = { 3,6,9,12,3,6,9 };
        int[] nonDupes = list
            .GroupBy(x => x)
            .Where(x => x.Count() == 1)
            .Select(x => x.Key)
            .ToArray();
        string output = string.Join(",", nonDupes);
        Console.WriteLine(output);
    }
