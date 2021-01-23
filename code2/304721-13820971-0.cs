        private string GetUninstallString(string msiName)
        {
            Utility.WriteLog("Entered GetUninstallString(msiName) - Parameters: msiName = " + msiName);
            string uninstallString = string.Empty;
            try
            {
                string path = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products";
                RegistryKey key = Registry.LocalMachine.OpenSubKey(path);
                foreach (string tempKeyName in key.GetSubKeyNames())
                {
                    RegistryKey tempKey = key.OpenSubKey(tempKeyName + "\\InstallProperties");
                    if (tempKey != null)
                    {
                        if (string.Equals(Convert.ToString(tempKey.GetValue("DisplayName")), msiName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            uninstallString = Convert.ToString(tempKey.GetValue("UninstallString"));
                            uninstallString = uninstallString.Replace("/I", "/X");
                            uninstallString = uninstallString.Replace("MsiExec.exe", "").Trim();
                            uninstallString += " /quiet /qn";
                            break;
                        }
                    }
                }
                return uninstallString;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
