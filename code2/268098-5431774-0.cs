    using (ServerManager serverManager = new ServerManager()) 
    { 
        
        var sites = serverManager.Sites; 
        foreach (Site site in sites) 
        { 
                 
            foreach (Application app in site.Applications)
            {
                Console.WriteLine("path: {0}", app.Path);
            }
        }
    }
