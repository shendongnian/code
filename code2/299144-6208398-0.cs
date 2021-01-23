    bool isLaunched = false;
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
                Thread.Sleep(1000);
                isLaunched = true;
            }
            else
            {
                Process.Start(url);
            }
        }
        catch (Exception ex)
        {
    // something
        }
    }
