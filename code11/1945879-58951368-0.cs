      using System.Linq;
      ...
      // static: we don't use "this"
      private static int[] Generate4Dir() {
        return Enumerable
          .Range(1, 5) // 1, 2, ..., 4
          .OrderBy(item => rnd.Next(-1, 1))
          .ToArray();
      } 
