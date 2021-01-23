    static void Main(string[] args)
    {
        int blockSize = 1024*1024; //1mb
        byte*[] handles = new byte*[1024];
        Console.WriteLine("Memory before : " + (Process.GetCurrentProcess().PrivateMemorySize64/1024)/1024); // get value in Megabytes
        try
        {
            for(int i=0; i<1024; i++)
            {
                handles[i] = (byte*)Marshal.AllocHGlobal(blockSize);
                //write to the memory
                for (int off = 0; off < blockSize; off++)
                    *(handles[i] + off) = 1;
            }
        }
        finally
        {
            //create a thread to ensure the memory continues to be accessed
            ManualResetEvent mreStop = new ManualResetEvent(false);
            Thread memoryThrash = new Thread(
                () =>
                    {
                        int ihandle = 0;
                        while (!mreStop.WaitOne(0, false))
                        {
                            for (int off = 0; off < blockSize; off++)
                                if (*(handles[ihandle++ % handles.Length] + off) != 1)
                                    throw new InvalidOperationException();
                        }
                    }
                );
            memoryThrash.IsBackground = true;
            memoryThrash.Start();
            Console.WriteLine("Memory after  : " + (Process.GetCurrentProcess().PrivateMemorySize64 / 1024)/1024);
            Console.WriteLine("Finished allocating 1024MB memory....Press Enter to free up.");
            Console.ReadLine();
            mreStop.Set();
            memoryThrash.Join();
        }
        try
        {
            for(int i=0; i<1024; i++)
            {
                Marshal.FreeHGlobal(new IntPtr(handles[i]));
            }
        }
        finally
        {
            Console.WriteLine("Memory at the end : " + (Process.GetCurrentProcess().PrivateMemorySize64 / 1024)/1024);
            Console.WriteLine("All allocated memory freed. Press Enter to quit..");
            Console.ReadLine();
        }
    }
