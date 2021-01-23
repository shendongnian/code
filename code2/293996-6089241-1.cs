    foreach(string keyname in root.GetSubKeyNames())
    {
        // use key to get value and set textbox4
  
        using (RegistryKey key = root.OpenSubKey(keyname))
        {
           MessageBox.Show(key.ValueCount.ToString());
        }
     }
 
