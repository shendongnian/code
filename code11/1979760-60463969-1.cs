using System;
using System.Linq;
					
public class Program
{
        public static void Main(string[] args)
        {
            int[] testInts = { 1, 2, 3, 4, 5 };
            testInts.Append(ref testInts,6);
            Console.WriteLine("Test Integers\n");
            foreach (int variable in testInts)
            {
                Console.WriteLine(Convert.ToString(variable));
            }            
            Console.WriteLine("\nPress any key to continue.");
        }
}
public static class Extentions {
        public static void Append(this int[] arr, ref int[] arr2, int value)
        {
            arr2 = arr.Concat(new[] { value }).ToArray();
        }
}
### Another way to make it work
If you are to make a new assignment, it does not make sense to even make an extention method.
public static int[] Append(int[] arr, int value)
{
    return arr.Concat(new[] { value }).ToArray();
}
// use like this
arr = Append(arr, 6);
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/passing-reference-type-parameters
