    private void btnGet_Click(object sender, EventArgs e)
    {
        ObjectCache cache = MemoryCache.Default;
        string fileContents = cache["filecontents"] as string;
    
        if (fileContents == null)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            
            List<string> filePaths = new List<string>();
            filePaths.Add("c:\\cache\\example.txt");
    
            policy.ChangeMonitors.Add(new 
            HostFileChangeMonitor(filePaths));
    
            // Fetch the file contents.
            fileContents = 
                File.ReadAllText("c:\\cache\\example.txt");
            
            cache.Set("filecontents", fileContents, policy);
        }
    
        Label1.Text = fileContents;
    }
