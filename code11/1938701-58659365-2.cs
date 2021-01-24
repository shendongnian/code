      using System.Linq;
      ... 
      int[] array = new int[] {1, 12, 123, 1234, 12345};
      int[] length = array
        .Select(item => item.ToString().Length)
        .ToArray();
