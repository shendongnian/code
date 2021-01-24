     using System.Linq;
     ...
     string source = "}çæø Ñ";
     Dictionary<char, int> result = source
       .GroupBy(c => c)
       .ToDictionary(group => group.Key, group => group.Count());
