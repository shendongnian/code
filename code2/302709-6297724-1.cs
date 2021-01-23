         protected override void OnStart(string[] args)
         {
            if (args.Contains("DEBUG_SERVICE))
                DebugMode();
    
    
             #if DEBUG
                 DebugMode();
             #endif
    
       
    
            }
    
        private static void DebugMode()
        {
    
            Debugger.Break();
        }
