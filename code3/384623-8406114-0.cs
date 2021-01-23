    namespace Test
    {
        using System;
        using System.Threading.Tasks;
        internal class TestCompile
        {
            private static void Main(string[] args)
            {
                Task t = new Task(() => Console.WriteLine("Executed!"));
                t.Wait(5000);
                Console.WriteLine("After wait...");
                Console.ReadKey();
            }
        }
    }
