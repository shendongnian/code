`
using System;
namespace ConsoleApp
{
  static partial class Program
  {
`
`
    static void Main(string[] args)
    {
      Test();
      Console.WriteLine();
      Console.WriteLine("End.");
      Console.ReadKey();
    }
`
`
    static void Test()
    {
      string[,] arr = 
      { 
        { "aakif", "25" }, 
        { "ali", "31" }, 
        { "ben", "35" }, 
        { "hassnain", "45" }
      };
      string search = "ali";
      string age = arr.GetAge(search);
      if ( age != null )
        Console.WriteLine($"{search} age = {age}");
      else
        Console.WriteLine($"{search} not found");
    }
`
`
    static string GetAge(this string[,] array, string name)
    {
      for ( int index = array.GetLowerBound(0); index <= array.GetUpperBound(0); index++ )
        if ( array[index, array.GetLowerBound(1)] == name )
          return array[index, array.GetUpperBound(1)];
      return null;
    }
`
`
  }
}
`
Output:
    ali age = 31
