    void Main()
    {
    	const int LOOPS = 5;
    	{
    		Console.WriteLine("When the arrays are kept inside the method's scope:");
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (starting memory)", GC.GetTotalMemory(false)));
    		for(int i = 0; i < LOOPS; i++)
    			this.AllocateArray(i);
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (exited local scope)", GC.GetTotalMemory(false)));
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (after GC collection ran)", GC.GetTotalMemory(true)));
    		
    		Console.WriteLine("\nWhen the arrays are outside the method's scope:");
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (starting memory)", GC.GetTotalMemory(false)));
    		var arrays = new byte[LOOPS][];
    		for(int i = 0; i < LOOPS; i++)
    			this.AllocateArray(i, arrays);
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (exited local scope)", GC.GetTotalMemory(false)));
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (after GC collection ran)", GC.GetTotalMemory(true)));
    		arrays[0][0] = 1; // Prevent the arrays from being optimized away
    	}
    	Console.WriteLine("\nAll scopes exited:");
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (before GC runs)", GC.GetTotalMemory(false)));
    		Console.WriteLine(String.Format("     GC Memory: {0:N0} bytes (after GC collection ran)", GC.GetTotalMemory(true)));
    }
    
    public void AllocateArray(int run)
    {
    	var array = new byte[20000000];
    	Thread.Sleep(100); // Simulate work..
    	Console.WriteLine(String.Format("[{0}] GC Memory: {1:N0} bytes (local array allocated)", run+1, GC.GetTotalMemory(false)));
    	array[0] = 1; // Prevent the array from being optimized away
    }
    
    public void AllocateArray(int run, byte[][] arrays)
    {
    	arrays[run] = new byte[20000000];
    	Thread.Sleep(100); // Simulate work..
    	Console.WriteLine(String.Format("[{0}] GC Memory: {1:N0} bytes (array allocated)", run+1, GC.GetTotalMemory(false)));
    }
