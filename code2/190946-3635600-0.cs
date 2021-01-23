    public class Program
    {
        static void Main()
        {
            Console.WriteLine(GCD(new[] { 10, 15, 30, 45 }));
        }
    
        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    
        static int GCD(int[] integerSet)
        {
            return integerSet.Aggregate(GCD);
        }    
    }
