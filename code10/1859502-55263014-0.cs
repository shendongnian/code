    public void SetTaskManager(bool enable)
        {
          // Load settings of desired user via UserName property
          using (PowerShell PowerShellInstance = PowerShell.Create())
          {
            var command = Properties.Settings.Default.LoadRegistryOfUser;
            command = command.Replace("USERNAME", UserName);
            PowerShellInstance.AddScript(command);
            var res = PowerShellInstance.Invoke();
          }
          
          // Create the key and entry for the registry or delete it if
          // enable == true
          RegistryKey objRegistryKey = Registry.Users.CreateSubKey(
             UserName + @"\Software\Microsoft\Windows\CurrentVersion\Policies\System");
          if (enable && objRegistryKey.GetValue("DisableTaskMgr") != null)
            objRegistryKey.DeleteValue("DisableTaskMgr");
          else
            objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
    
          objRegistryKey.Close();
          
          // Close the registry of the user, otherwise he cant log on
          using (PowerShell PowerShellInstance = PowerShell.Create())
          {
            var command = Properties.Settings.Default.CloseRegistryOfUser;
            command = command.Replace("USERNAME", UserName);
            PowerShellInstance.AddScript(command);
            var res = PowerShellInstance.Invoke();
          }
        }
