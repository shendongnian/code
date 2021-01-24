    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Repeat(TimeSpan.FromSeconds(10));
                Console.ReadKey();
            }
    
            private static void Repeat(TimeSpan period)
            {
                Task.Delay(period)
                    .ContinueWith(
                        t =>
                        {
                                //Do your staff here
                                Console.WriteLine($"Time:{DateTime.Now}");
                            Repeat(period);
                        });
            }
        }
    
    }
