        private static string FIRST_RUN_FLAG = "FIRST_RUN_FLAG";
        private static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public bool IsFirstRun()
        {
            if (!settings.Contains(FIRST_RUN_FLAG))
            {
                settings.Add(FIRST_RUN_FLAG, false);
                return true;
            }
            else
            {
                return false;
            }
        }
