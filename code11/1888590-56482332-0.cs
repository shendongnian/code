    static void Main(string[] args)
    {
    	ProcessStartInfo psi = new ProcessStartInfo
    	{
    		FileName = "cmd.exe",
    		Arguments = "/c ",
    	};
    
    	using (Process proc = Process.Start(psi))
    		proc.WaitForExit();
    
    	Console.ReadKey();
    }
