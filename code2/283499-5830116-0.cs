    using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SomeKey"))
    {
        string[] subKeys = key.GetSubKeyNames();
        string[] valueNames = key.GetValueNames();
        string myValue = (string)key.GetValue("myValue");
    }
