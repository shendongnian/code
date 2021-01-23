        public static void FindInstalled(AppName)
        {
            RegistryKey myRegKey = Registry.LocalMachine;
            myRegKey = myRegKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
            String[] subkeyNames = myRegKey.GetSubKeyNames();
            foreach (String s in subkeyNames)
            {
                RegistryKey UninstallKey = Registry.LocalMachine;
                UninstallKey = UninstallKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + s);
                Object oValue = UninstallKey.GetValue("DisplayName");
                if (oValue != null)
                {
                    if (oValue.ToString() == AppName)
                    {
                        oValue = UninstallKey.GetValue("UninstallString");
                        Console.Writeline("Uninstall URL - {0}", oValue.ToString());
                        break;
                    }
                }
            }
        }
