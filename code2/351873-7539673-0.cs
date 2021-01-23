        void ReadReg(string key, params Action<RegistryKey>[] results)
        {
            var k = Registry.CurrentUser.OpenSubKey(key);
            if (k != null)
            {
                foreach (var item in results)
                {
                    item(k);
                }
                k.Close();
            }
        }
    
        void WriteReg(string key, params Action<RegistryKey>[] results)
        {
            var k = Registry.CurrentUser.OpenSubKey(key, true);
            if (k != null) k = Registry.CurrentUser.CreateSubKey(key);
            foreach (var item in results)
            {
                item(k);
            }
            k.Close();
        }
