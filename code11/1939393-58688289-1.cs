    public class Program
    {
    	public static void Main()
        {
           PizzaTask().GetAwaiter().GetResult();
        }
    
        static async Task PizzaTask()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalPizza = 10;
            Console.WriteLine("Started preparing " + totalPizza + "  pizza");
    		
    		var tasks = Enumerable.Range(0, totalPizza).Select(i => MakePizza(i));
    		await Task.WhenAll(tasks).ConfigureAwait(false);
    		
            stopwatch.Stop();
    
            Console.WriteLine("Finished preparing " + totalPizza + "  pizza");
            Console.WriteLine("Elapsed time: " + stopwatch.Elapsed.TotalSeconds);
    
        }
    
        static async Task MakePizza(int n)
        {
            await PreparePizza(n).ConfigureAwait(false);
            await BakePizza(n).ConfigureAwait(false);
        }
    
        static async Task PreparePizza(int n)
        {
            Console.WriteLine("Start preparing pizza " + n);
    		await Task.Delay(5000);
            //Thread.Sleep(5000);// synchronous
            Console.WriteLine("Finished preparing pizza " + n);
        }
    
        static async Task BakePizza(int n)
        {
            Console.WriteLine("Start baking pizza " + n);
            await Task.Delay(15000); // asynchronous 
            //Thread.Sleep(15000); // synchronous 
            Console.WriteLine("Finished baking pizza " + n);
        }
    }
