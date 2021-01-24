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
                Console.WriteLine(N);
                return N;
            }
            else
            {
                Console.Write("{0}+", N);
                return N + SumFrom(N + 1, M);
            }
    	}
    }
