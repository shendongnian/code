     static void Main(string[] args)
     {
         Console.WriteLine("Enter a beginning value between 1 and 100");
         int s = Convert.ToInt32(Console.ReadLine());
         if (s < 0 || s > 100)
             Console.WriteLine("Invalid input. Try again.");
         else
             Console.WriteLine($"Sum of values: {Enumerable.Range(1,s).Sum()}");
     }
