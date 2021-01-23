            static unsafe void Main(string[] args)
            {
                ulong val = 1;// some variable space to store an integer
                ulong* addr = &val;
                ulong read = *addr;
    
                Console.WriteLine("Val at {0} = {1}", (ulong)addr, read);
    
    #if DEBUG 
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
    #endif
            }
