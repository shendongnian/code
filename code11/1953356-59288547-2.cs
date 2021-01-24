     using System.Linq;
     ...
     Dictionary<string, string> dict = File
       .ReadLines(@"N:\Desktop\krew.txt")
       .Where(line => !string.IsNullOrEmpty(line)) // to be on the safe side
       .Select(line => line.Split('\t'))
       .ToDictionary(items => items[0], items => items[1]);
