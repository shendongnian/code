    class ThreadEnvironmentSettings
    {
    	[ThreadStatic]
    	public static readonly ThreadEnvironmentSettings Settings = 
             new ThreadEnvironmentSettings();
    
        public ThreadEnvironmentSettings()
        {
            SetupJavaEnvironment();
        }
        
        public void EnsureSetup(){
        	// Doesn't do anything but required to 'touch' the thread variable
        }
    }
