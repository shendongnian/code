    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        new Program().Run(args);
    }
    void Run(string[] args)
    {
        var domain = PrimaryAppDomainManager.CreateInitialDomain("PrimaryDomain", null, null);
        if (domain == null)
        {
            // Original Main() code here.
        }
        else
        {
            domain.CreateInstanceAndUnwrap<Program>().Run(args);
        }
    }
