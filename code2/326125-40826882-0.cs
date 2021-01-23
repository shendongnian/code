    static void Main( string[] args )
    {
        hook_keys();
        AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
        while (true) { System.Threading.Thread.Sleep( new TimeSpan(0,10,0) ); }
    }
    private static void CurrentDomainOnProcessExit(object sender, EventArgs eventArgs )
    {
        unhook_keys();
    }
