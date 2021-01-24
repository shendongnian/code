    private static bool TerminateThreads = false;
    public static void StartSocket()
    {
        Server myserver = new Server(*, ****);
        while(!TerminateThreads) 
        { 
            try { ExecuteSomething();  }
            catch { TerminateThreads = true; }
        }
    }
    public static void StartWeb()
    {
        CreateWebHostBuilder().Build().Run();
        while(!TerminateThreads) 
        { 
            try { ExecuteOtherSomething();  }
            catch { TerminateThreads = true; }
        }
    }
