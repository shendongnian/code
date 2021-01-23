    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Program
    {
      static void Main()
      {
        var distributions = Distributions(4, 3);
        PrintSequences(distributions);
        Console.ReadKey(true);
      }
      
      /// <summary>
      /// Entry point for the other recursive overload
      /// </summary>
      /// <param name="length">Number of elements in the output</param>
      /// <param name="range">Number of distinct values elements can take</param>
      /// <returns></returns>
      static List<int[]> Distributions(int length, int range)
      {
        var distribution = new int[range];
        var distributions = new List<int[]>();
        Distributions(0, length, distribution, 0, distributions);
        return distributions;
      }
      /// <summary>
      /// Recursive methode. Not to be called directly, only from other overload
      /// </summary>
      /// <param name="index">Value of the (possibly) last added element</param>
      /// <param name="length">Number of elements in the output</param>
      /// <param name="distribution">Distribution among element distinct values</param>
      /// <param name="sum">Exit condition of the recursion. Incremented if element added from parent call</param>
      /// <param name="distributions">All possible distributions</param>
      static void Distributions(int index,
                                int length,
                                int[] distribution,
                                int sum,
                                List<int[]> distributions)
      {
        //Uncomment for exactness check
        //System.Diagnostics.Debug.Assert(distribution.Sum() == sum);
        if (sum == length)
        {
          distributions.Add((int[])distribution.Clone());
    
          for (; index < distribution.Length; index++)
          {
            sum -= distribution[index];
            distribution[index] = 0;
          }
          return;
        }
        if (index < distribution.Length)
        {
          Distributions(index + 1, length, distribution, sum, distributions);
          distribution[index]++;
          Distributions(index, length, distribution, ++sum, distributions);
        }
      }
      static void PrintSequences(List<int[]> distributions)
      {
        for (int i = 0; i < distributions.Count; i++)
        {
          for (int j = 0; j < distributions[i].Length; j++)
            for (int k = 0; k < distributions[i][j]; k++)
              Console.Write("{0:D1} ", distributions[i].Length - 1 - j);
          Console.WriteLine();
        }
      }
    }
