     using System.Text.RegularExpressions;
     ...
     string source = "400X500 abc";
     string[] numbers = Regex
       .Matches(source, "[0-9]+") 
       .OfType<Match>()
       .Select(match => match.Value)
       .ToArray(); 
     string width = numbers.ElementAtOrDefault(0);
     string height = numbers.ElementAtOrDefault(1);
     
