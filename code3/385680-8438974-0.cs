    using System;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething();
    
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    
        static async void DoSomething()
        {
            Console.WriteLine("Starting DoSomething ...");
    
            var x = await PrepareAwaitable(1);
    
            Console.WriteLine("::" + x);
    
            var y = await PrepareAwaitable(2);
    
            Console.WriteLine("::" + y);
        }
    
        static async Task<string> PrepareAwaitable(int x)
        {
            return "Howdy " + x;
        }
    }
