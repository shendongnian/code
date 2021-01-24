    using System.Linq;
    using System.Text.RegularExpressions;
    ...
    string str = "['2','4','5','1']";
    var result = Regex
      .Matches(str, @"\-?[0-9]+")              // \-? for negative numbers
      .Cast<Match>()
      .Select(match => int.Parse(match.Value)) // int.Parse if you want int, not string
      .ToList();
