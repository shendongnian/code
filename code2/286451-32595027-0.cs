    public static void Kill()
    {
    	try
    	{
    			ProcessStartInfo processStartInfo = new ProcessStartInfo("taskkill", "/F /T /IM your_parent_process_to_kill.exe")
    			{
    				WindowStyle = ProcessWindowStyle.Hidden,
    				CreateNoWindow = true,
    				UseShellExecute = false,
    				WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory,
    				RedirectStandardOutput = true,
    				RedirectStandardError = true
    			};
    			Process.Start(processStartInfo);
    	}
    	catch { }
    }
