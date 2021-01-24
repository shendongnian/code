    // Write
    RegistryKey setKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\mySettings", RegistryKeyPermissionCheck.ReadWriteSubTree);
    setKey.SetValue("Set", DateTime.Now.Ticks, RegistryValueKind.QWord);
    setKey.Close();
    
    // Read
    RegistryKey getKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\mySettings");
    var date = new DateTime((long)getKey.GetValue("Set"));
    getKey.Close();
