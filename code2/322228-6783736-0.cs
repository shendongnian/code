    RegistryKey keys = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU");
    
    foreach (string subKeyName in keys.GetSubKeyNames())
    {
    	using(RegistryKey tempKey = keys.OpenSubKey(subKeyName))
                {
                    Console.WriteLine("\nThere are {0} values for {1}.", 
                        tempKey.ValueCount.ToString(), tempKey.Name);
    
                    foreach(string valueName in tempKey.GetValueNames())
                    {
                        Console.WriteLine("{0,-8}: {1}", valueName, 
                            tempKey.GetValue(valueName).ToString());
                    }
                }
    }
