    static void Main(string[] args)
    {
        Console.WriteLine("Before allocation");
        var bo = new BigObject();
        Console.WriteLine("After allocation");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("After garbage collection");
        Console.ReadLine();
        // The object is technically in-scope here which means it must still be rooted.
    }
    
    private class BigObject
    {
        private byte[] LotsOfMemory = new byte[Int32.MaxValue / 4];
    
        public BigObject()
        {
            Console.WriteLine("BigObject()");
        }
    
        ~BigObject()
        {
            Console.WriteLine("~BigObject()");
        }
    }
