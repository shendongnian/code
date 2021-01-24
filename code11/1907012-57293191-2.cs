      using System.Linq;
      ...
      string str = "abcdef";
      // {1, 1, 1, 1, 1, 1} - each letter appears once 
      int[] result = str
        .ToLower()
      //.Where(c => c >= 'a' && c <= 'z') // uncomment, if we want 'a'..'z' range only 
        .GroupBy(c => c)
        .Select(group => group.Count())
        .ToArray();
      Console.Write(string.Join(", ", result));
