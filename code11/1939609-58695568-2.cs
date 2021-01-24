    using System;
    using System.Linq;
    public static void Main(string[] args)
    {
        Console.WriteLine("C# Exercise!");
        Console.WriteLine("Please enter two numbers seperated by space to start calculating: ");
        var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), decimal.Parse);
    	
        Console.WriteLine("Result: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
        decimal numberOne = numbers.FirstOrDefault(); 
        decimal numberTwo = numbers.LastOrDefault(); //Your second element will be last element in array
        Console.WriteLine(SumTrippler.Calculate(numberOne, numberTwo));
        Console.ReadKey();
    }
