    public class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 1; i < 10000; i++)
            {
                list.Add(i);
            }
            var batched = list.Batch(681);
            // will print 15. The 15th element has 465 items...
            Console.WriteLine(batched.Count().ToString());  
            Console.WriteLine(batched.ElementAt(14).Count().ToString());
            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
