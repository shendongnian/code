    List<string> hkey = new List<string>();
            try
            {
                // Open HKEY_USERS
                // on a remote computer.
                string remoteName = host;
                RegistryKey environmentKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.Users, remoteName);
                foreach (string subKeyName in environmentKey.GetSubKeyNames())
                {
                    hkey.Add(subKeyName);
                }
                // Close the registry key.
                environmentKey.Close();
            }
            catch
            {
            }
