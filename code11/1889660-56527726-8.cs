      using System.Linq;
      ...
      var result = input.Split(
        separators.OrderByDescending(item => item.Length), // longest first
        StringSplitOptions.RemoveEmptyEntries);
