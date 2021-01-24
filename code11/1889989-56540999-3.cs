     using System.Linq;
     ...
     // If you want to create a dictionary:
     Dictionary<string, string> result = source
       .GroupBy(pair => pair.Value)
       .ToDictionary(
          chunk => string.Join(", ", chunk.Select(pair => pair.Key)),
          chunk => chunk.Key);
     string report = string.Join(Environment.NewLine, result
       .Select(pair => $"{pair.Key} : {pair.Value}"));
     Console.Write(report);
