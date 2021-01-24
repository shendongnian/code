    using System.Linq;
    ...
    public static int[] Divisors(int n)
      {
        ...
        if (divisors.Count > 0)
        {
          // Order List, create an array from it and, finally, return the array
          return divisors.OrderBy(item => item).ToArray();
        }
        else
          //TODO: better return an empty array: return int[0]; 
          return null;
      }
