        class Program
    {
        static void Main(string[] args)
        {
            UseAsync.UseAsyn();
            Console.ReadLine();
        }
    }
    static class UseAsync
    {
        public static async Task UseAsyn()
        {
            Console.WriteLine("Foo");
            await Do();
        }
        private static async Task Do()
        {
            await Task.Delay(2000);
            Console.WriteLine("Bar");
        }
    }
