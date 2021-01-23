    private Process myProcess = new Process();
    private int elapsedTime;
    private bool eventHandled;
    
    public void RunFfmpeg(string arguments)
    {    
    	elapsedTime = 0;
    	eventHandled = false;
    
    	try
    	{
    		myProcess.StartInfo.FileName = "ffmpeg.exe";
            myProcess.StartInfo.Arguments = arguments;
    		myProcess.StartInfo.CreateNoWindow = true;
    		myProcess.EnableRaisingEvents = true;
    		myProcess.Exited += new EventHandler(myProcess_Exited);
    		myProcess.Start();    
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine("An error occurred trying to print \"{0}\":" + "\n" + ex.Message, fileName);
    		return;
    	}
    
    	// Wait for Exited event, but not more than 30 seconds.
    	const int SLEEP_AMOUNT = 100;
    	while (!eventHandled)
    	{
    		elapsedTime += SLEEP_AMOUNT;
    		if (elapsedTime > 30000)
    		{
    			break;
    		}
    		Thread.Sleep(SLEEP_AMOUNT);
    	}
    }
    
    private void myProcess_Exited(object sender, System.EventArgs e)
    {    
    	eventHandled = true;
    	Console.WriteLine("Exit time:    {0}\r\n" +
    		"Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
    }
