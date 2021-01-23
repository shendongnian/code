    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo( );
            Func<int[], int> SumArgs = foo.AddArgs; // creates the delegate instance
    
            //  get some values
            int[] nums = new[] { 4, 5, 6 };
    
            var result = SumArgs(nums); // invokes the delegate
            Console.WriteLine("result = {0}", result1);
            Console.ReadKey( );
        }
    }
    
    internal class Foo
    {
        internal int AddArgs(params int[] args)
        {
            int sum = 0;
    
            foreach (int arg in args)
            {
                sum += arg;
            }
    
            return sum;
        }
    }
