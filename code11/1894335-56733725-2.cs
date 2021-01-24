    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Enter the N:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the M:");
            int M = int.Parse(Console.ReadLine());
            var result = Program.SumFrom(N,M);
    		Console.Write("={0}", result);
    	}
    	public static int SumFrom(int N, int M) {
    		if (N == M)
            {
                Console.Write(N);
                return N;
            }
            else
            {
                Console.Write("{0}+", N); // this line prints current number on console.
                return N + SumFrom(N + 1, M); // code edited, you are not calling a method properly. 
            }
    	}
    }
