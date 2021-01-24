    using System;
    using System.Timers;
    using System.Threading.Tasks;
    namespace actionexample
    {
        class Program
        {
        static void Main(string[] args)
        {
            Action<string, string> resultHandler = (a,b,) => {
                //Do something
            }
            Func<string, string, Action<string, string>, Task> testFunc = async (f, n, h) =>
            {
                Console.WriteLine("Starting Action");
                f += n;
                Console.WriteLine(f);
                await Task.Delay(100);
                h(f, n);
            };
            SubscribeToConfigAsync<string>("1", "2", testFunc);
            Console.Write("END");
            Console.ReadLine();
           
        }
        static void SubscribeToConfigAsync<T>(string feature, string name, Func<string, string, Action<string, string>, Task> action, Action<string, string> handler)
        {
            var timer = new Timer(5000);
            timer.Elapsed += async (sender, e) => await action(feature, name, handler);
            timer.Start();
        }
    }
    
