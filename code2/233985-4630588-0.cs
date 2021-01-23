     protected override void OnStart(string[] args)
         {
            foreach (string arg in args)
            {
                if (arg == "DEBUG_SERVICE")
                        DebugMode();
    
            }
         #if DEBUG
             DebugMode();
         #endif
         eventLog1.WriteEntry("Service Started");
         timer1.Elapsed += timer1_Elapsed;
         timer1.Interval = 10000;
         timer1.Enabled = true;
        }
    private static void DebugMode()
    {
        Debugger.Break();
    }
