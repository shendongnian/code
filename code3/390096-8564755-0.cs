    private static void Main(string[] args)
    {
    	Process.Start("notepad");
    
    	Console.WriteLine("Started notepad");
    	Wait();
    	Console.WriteLine("Wait complete");
    
    	Console.ReadKey();
    }
    
    private static void Wait()
    {
    	Process myProcess = Process.GetProcessesByName("notepad").FirstOrDefault();
    	if (myProcess != null)
    	{
    		myProcess.EnableRaisingEvents = true;
    		myProcess.Exited += (sender, e) =>
    			{
    				Console.WriteLine("Notepad exited");
    			};
    	}
    }
