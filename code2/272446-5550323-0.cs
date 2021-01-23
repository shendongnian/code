    static void GetInstalled()
    {
          string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
          using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
          {
                foreach (string skName in rk.GetSubKeyNames())
                {
                      using (RegistryKey sk = rk.OpenSubKey(skName))
                      {
                            Console.WriteLine(sk.GetValue("DisplayName"));
                      }
                }
          }
    }
    
