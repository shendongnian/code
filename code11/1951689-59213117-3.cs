      using System.Linq;
      ...
      string result = string.Join(",", Enumerable
        .Range(1, 13)
        .Select(suffix => $"1.{suffix}"));
      Console.Write(result);
