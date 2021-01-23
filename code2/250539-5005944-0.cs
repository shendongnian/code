    try
    {
    
        Process p = new Process();
        StringBuilder sb = new StringBuilder("/COVERAGE ");
        sb.Append("hello.exe");
        p.StartInfo.FileName = "vsinstr.exe";
        p.StartInfo.Arguments = sb.ToString();
        p.Start(); 
        p.WaitForExit(); 
    
    }
    catch(Exception ex)
    {
       // Handle exception
    }
