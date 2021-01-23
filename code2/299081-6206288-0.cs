foreach (string url in urls)
{
    try
    {
        if (!isLaunched)
        {
            Process p = new Process();
            p.StartInfo.FileName = browser;
            p.StartInfo.Arguments = url;
            p.Start();
            if(!p.WaitForInputIdle()){ //Should wait indefinitely until the 
                                       //process is idle
              Thread.Sleep(1000);// Just in case the process has no message loop
            }
            isLaunched = true;
        }
        else
        {
            Process.Start(url);
        }
    }
}
