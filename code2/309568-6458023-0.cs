     public static List<String> GetSystemDriverList()
            {
                List<string> names = new List<string>();
                // get system dsn's
                Microsoft.Win32.RegistryKey reg = (Microsoft.Win32.Registry.LocalMachine).OpenSubKey("Software");
                if (reg != null)
                {
                    reg = reg.OpenSubKey("ODBC");
                    if (reg != null)
                    {
                        reg = reg.OpenSubKey("ODBCINST.INI");
                        if (reg != null)
                        {
    
                            reg = reg.OpenSubKey("ODBC Drivers");
                            if (reg != null)
                            {
                                // Get all DSN entries defined in DSN_LOC_IN_REGISTRY.
                                foreach (string sName in reg.GetValueNames())
                                {
                                    names.Add(sName);
                                }
                            }
                            try
                            {
                                reg.Close();
                            }
                            catch { /* ignore this exception if we couldn't close */ }
                        }
                    }
                }
    
                return names;
            }
          
