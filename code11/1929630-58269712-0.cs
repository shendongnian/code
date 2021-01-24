    using System;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                //Waits the API response
                GetUser().Wait();
                //Waits until a key is pressed.
                Console.ReadKey();
            }
            // retrieve all.
            public static async Task GetUser()
            {
               //...
            }
        }
    }
