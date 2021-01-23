    private static void SortOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {	
    	if (!String.IsNullOrEmpty(outLine.Data))
    	{
    		Console.WriteLine(outLine.Data);
    		 System.IO.File.AppendAllText("c:\test\log.txt", outLine.Data); 
    	}
    }
