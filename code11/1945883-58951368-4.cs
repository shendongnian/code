      using System.Linq;
      ...
      // static: we don't use "this"
      private static int[] Generate4Dir() {
        return Enumerable
          .Range(1, 4)                      // 4 items starting from 1: 1, 2, 3, 4
          .OrderBy(item => rnd.Next(-1, 1)) // ordered by rnd.Next(-1, 1) criterium
          .ToArray();                       // materialized as an array
      } 
