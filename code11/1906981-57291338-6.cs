    using System.Linq;
    ... 
    private static IEnumerable<int[]> Solution(int[] maxes) {
      if (null == maxes || maxes.Length <= 0 || maxes.Any(item => item < 1))
        yield break; // Or throw exception(s)
      int[] current = Enumerable
        .Repeat(1, maxes.Length)
        .ToArray();
      do {
        yield return current.ToArray(); // copy of current
        for (int i = current.Length - 1; i >= 0; --i)
          if (current[i] < maxes[i]) {
            current[i] += 1;
            break;
          }
          else
            current[i] = 1;
      }
      while (!current.All(item => item == 1));
    }
    ...
    // Having an enumeration, we materialize it as an array, i.e. array of array
    int[][] demo = Solution(new int[] { 2, 3, 2})
      .ToArray();
    // Let's have a look at the results
    Console.Write(string.Join(Environment.NewLine, 
      demo.Select(line => string.Join(", ", line))));
