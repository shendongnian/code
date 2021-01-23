        private static string FIRST_RUN_FLAG = "FIRST_RUN_FLAG";
        private static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
       private static string _CurrentVersion;
        public static string CurrentVersion
        {
            get
            {
                if (_CurrentVersion == null)
                {
                    var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).FirstOrDefault() as AssemblyFileVersionAttribute;
                    if (versionAttribute != null)
                    {
                        _CurrentVersion = versionAttribute.Version;
                    }
                    else _CurrentVersion = "";
                }
                return _CurrentVersion;
            
            }
            
        }
        
        public static void OnFirstUpdate(Action<String> action)
        {
            if (!settings.Contains(FIRST_RUN_FLAG))
            {
                settings.Add(FIRST_RUN_FLAG, CurrentVersion);
                action(CurrentVersion);
            }
            else if (((string)settings[FIRST_RUN_FLAG]) != CurrentVersion) //It Exits But Version do not match
            {  
                settings[FIRST_RUN_FLAG] = CurrentVersion;
                action(CurrentVersion);
                
            }
          
        }
