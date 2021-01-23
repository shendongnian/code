    // C# Program to print all prime factors 
    using System; 
      
    namespace prime
    {
        public class Prime
        { 
    
            public static void PrimeFactors(int n)
            {
                Console.Write($"Prime Factors of {n} are:  ");
    
                // Prints all the numbers of 2  
                while (n % 2 == 0)
                {
                    Console.Write("2 ");
                    n /= 2;
                }
    
                // As no 2 can be further divided, this probably means that n
                // is now an odd number
                for(int i = 3; i <= Math.Sqrt(n); i += 2)
                {
                    while (n % i == 0)
                    {
                        Console.Write($"{i} ");
                        n /= i;
                    }
                }
    
                // This is for case if n is greater than 2
                if (n > 2)
                {
                    Console.Write($"{n} ");
                }
    
            }
    
            // Prompts user to give Input to number and passes it on 
            // the PrimeFactors function after checking its format
            public static void RunPrimeFactors()
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    PrimeFactors(n);
                }
                else
                {
                    Console.WriteLine("You entered the wrong format");
                }
    
            }
            // Driver Code 
            public static void Main()
            {
                RunPrimeFactors();
            }
    
        }
    }
