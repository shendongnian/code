    public bool ValueExists(RegistryKey Key, string Value)
    {
       try
       {
           return Key.GetValue(Value) != null;
       }
       catch
       {
           return false;
       }
    }
