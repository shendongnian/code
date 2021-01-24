    public static bool WriteRegistryValue<T>(RegistryHive hive, string key, string value, RegistryValueKind kind, T data)
            {
                bool success = false;
    
                using (RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(hive, String.Empty))
                {
                    if (baseKey != null)
                    {
                        using (RegistryKey registryKey = baseKey.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree))
                        {
                            if (registryKey == null)
                            {
                                using (RegistryKey createdRegistryKey = baseKey.CreateSubKey(key, true))
                                {
                                    registryKey.SetValue(value, data as string);
                                }
                            }
                            else
                            {
                                registryKey.SetValue(value, data as string);
                            }
                            success = true;
    
                        }
                    }
                }
                return success;
            }
