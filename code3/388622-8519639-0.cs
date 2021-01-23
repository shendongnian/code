    public string GetDotnetVersions()
    {
                string allversion=null;
                string  friendlyName, version;
               
                RegistryKey componentsKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Active Setup\\Installed Components");
                string[] instComps = componentsKey.GetSubKeyNames();
                foreach (string instComp in instComps)
                {
                    RegistryKey key = componentsKey.OpenSubKey(instComp);
                    friendlyName = (string)key.GetValue(null); // Gets the (Default) value from this key
                    if (friendlyName != null && friendlyName.IndexOf(".NET Framework") >= 0)
                    {
                        // Let's try to get any version information that's available
                        version = (string)key.GetValue("Version");
                        if (version != null && version.Split(',').Length >= 4)
                        {
                            allversion += version + Environment.NewLine;
                        }
                            
                    }
                }
           return allversion;
      }
