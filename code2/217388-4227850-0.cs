    class Program
    {
        static void Main()
        {
            // add an item to the cache
            HttpRuntime.Cache["foo"] = "bar";
            Console.WriteLine(HttpRuntime.Cache["foo"]); // prints bar
            // remove the item from the cache
            HttpRuntime.Cache.Remove("foo");
            Console.WriteLine(HttpRuntime.Cache["foo"]); // prints empty string
        }
    }
