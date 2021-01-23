    public static int GetIIsMajorVersion()
    {
      string regKey = @"SOFTWARE\Microsoft\InetStp";
      using(RegistryKey key = Registry.LocalMachine.OpenSubKey(regKey, true))
      {
        return Convert.ToInt32(key.GetValue("MajorVersion"));
      }
    }
