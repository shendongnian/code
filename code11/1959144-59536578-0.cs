    class Program
    {
        static MemoryStream GetMemoryStream()
        {
            using (MemoryStream mem = new MemoryStream())
            {
                return mem;
            }
        }
        static void Main(string[] args)
        {
            MemoryStream mem = GetMemoryStream();
            Console.WriteLine(mem.Length);
        }
    }
