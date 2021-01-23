        public bool Write(RegistryKey baseKey, string keyPath, string KeyName, object Value)
        {
            try
            {
                // Setting 
                RegistryKey rk = baseKey;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only 
                RegistryKey sk1 = rk.CreateSubKey(keyPath);
                // Save the value 
                sk1.SetValue(KeyName.ToUpper(), Value);
                return true;
            }
            catch (Exception e)
            {
                // an error! 
                MessageBox.Show(e.Message, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }
