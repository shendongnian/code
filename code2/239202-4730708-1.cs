    class Example
    {
        private static void Main()
        {
            int? i = new int?();
            Console.WriteLine(false);
            Console.WriteLine(!i.HasValue);
        }
    }
