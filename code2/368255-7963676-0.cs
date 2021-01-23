    using System.Text.RegularExpressions;
    var split = str.Split(',').SelectMany(s => Regex.IsMatch(s, @"^\d")
              ? new [] {s} 
              : s.ToCharArray().Select(c => c.ToString()))
         .ToList();
