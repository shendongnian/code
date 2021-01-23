        private void DeleteRegistryKey()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (null != key && IsStartupItem())
                {
                    key.DeleteValue("MyApp");
                }
            }
        }
        private bool IsStartupItem()
        {
            // The path to the key where Windows looks for startup applications
            RegistryKey regApp = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (regApp.GetValue("MyApp") == null)
                // The value doesn't exist, the application is not set to run at startup
                return false;
            else
                // The value exists, the application is set to run at startup
                return true;
        }
        private void SetRegistry(string path)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "MyApp", path);
        }
