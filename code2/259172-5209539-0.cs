    long nTotalMem1 = System.GC.GetTotalMemory(true);
    Foo[] arr = new Foo[1000];
    for (int i = 0; i < 1000; i++)
    {
    	arr[i] = new Foo(42);
    }
    long nTotalMem2 = System.GC.GetTotalMemory(true);
    Console.WriteLine("Memory consumption: " + (nTotalMem2 - nTotalMem1) + " bytes");
