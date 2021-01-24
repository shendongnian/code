    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        Foo().Wait();
        //    }
        //    catch (FooException)
        //    {
        //        Console.WriteLine("Yep, its a Foo Exception");
        //    }
        //    catch (AggregateException)
        //    {
        //        Console.WriteLine("Damn it, we got an Aggregate");
        //    }
        //    Console.ReadKey();
        //}
        static async Task Main(string[] args)
        {
            try
            {
                await Foo();
            }
            catch (FooException)
            {
                Console.WriteLine("Yep, its a Foo Exception");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Damn it, we got an Aggregate");
            }
            Console.ReadKey();
        }
        class FooException : Exception
        {
        }
        static async Task<int> Foo()
        {
            await Task.Delay(100);
            var foo = 42;
            if (foo == 42) {
                throw new FooException(); // want it to break here
            }
            
            return 43;
        }
    }
