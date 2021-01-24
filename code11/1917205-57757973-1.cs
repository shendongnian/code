    string s = "xgdgyd";
    var result = s
       .OrderBy(c => c)
       .GroupBy(c => c)
       .Select(g => g.Key.ToString() + g.Count());
    Console.WriteLine(string.Join("", result)); // Outputs "d2g2x1y1"
