        void InstallMeOnStartUp()
        {
            try
            {
                Microsoft.Win32.RegistryKey key =   Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
            }
            catch (Exception ex)
            {
                //
            }
        }
