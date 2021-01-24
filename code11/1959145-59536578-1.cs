    class Program
    {
        static MemoryStream GetMemoryStream()
        {
            using (MemoryStream mem = new MemoryStream())
            {
                // BAD CODE - BUG!
                return mem;
                // The above will return an object which is about to be Disposed!
            }
        }
        static void Main(string[] args)
        {
            MemoryStream mem = GetMemoryStream();
            Console.WriteLine(mem.Length);
        }
    }
