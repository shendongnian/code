       using System.Linq;
       ...
       static void Main(string[] args)
       {
           int[] Array = File
             .ReadLines("Data.Txt")
             .Select(item => int.Parse(item))
             .ToArray();
           Console.WriteLine("ARRAY BEFORE SORTING");
           ...
