csharp
namespace ParallelDemo
{
    class Program
    {
        static void Main()
        {
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2
            };
            List<int> integerList = Enumerable.Range(0,10).ToList();
            Parallel.ForEach(integerList, options, i =>
            {
                Console.WriteLine(@"value of i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
            });
            
            Console.WriteLine("Press any key to exist");
            Console.ReadLine();
        }
    }
}
**Note: It will speed up but you're going to use more memory**
