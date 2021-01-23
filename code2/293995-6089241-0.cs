    foreach(string keyname in root.GetSubKeyNames()_
    {
        // use key to get value and set textbox4
  
        using (RegistryKey key = root.OpenSubKey(keyname))
        {
           MessageBox.Show(key.ValueCount.ToString());
        }
     }
 
