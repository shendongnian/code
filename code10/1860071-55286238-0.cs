    new Thread(() =>
    {
    Thread.CurrentThread.IsBackground = true;
    
    while (run)
    {
        foreach (string path in paths)
        {
            Thread.Sleep(100);
            try
            {
                var fileName = Path.GetFileName(path); // Get the file name
                var fullDestination = dir + fileName;  // Complete the uri
                File.Copy(path, fullDestination, true);
            }
            catch (Exception e)
            {
                g.log.WriteToLog("Failed to copy asset: " + e.ToString());
    
            }
        }
    };
    
    }).Start();
