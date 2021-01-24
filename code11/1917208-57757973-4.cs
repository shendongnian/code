    string s = "xgdgyd";
    var result = s
       .GroupBy(c => c)
       .Select(g => g.Key.ToString() + g.Count())
       .OrderBy(x => x);
    Console.WriteLine(string.Concat(result)); // Outputs "d2g2x1y1"
