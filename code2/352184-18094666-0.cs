    public static class AzureStorageEmulatorManager
    {
    	private const string processName = "DSServiceLDB";
    	private static readonly ProcessStartInfo processStartInfo = new ProcessStartInfo
    		{
    			FileName = @"C:\Program Files\Microsoft SDKs\Windows Azure\Emulator\csrun.exe",
    			Arguments = "/devstore",
    		};
    
    	public static Process GetProcess()
    	{
    		return Process.GetProcessesByName(processName).FirstOrDefault();
    	}
    
    	public static bool IsProcessStarted()
    	{
    		return GetProcess() != null;
    	}
    
    	public static void StartProcess()
    	{
    		if (!IsProcessStarted())
    		{
    			using (Process process = Process.Start(processStartInfo))
    			{
    				process.WaitForExit();
    			}
    		}
    	}
    
    	public static void StopProcess()
    	{
    		Process process = GetProcess();
    		if (process != null)
    		{
    			process.Kill();
    		}
    	}
    }
