    static void GetFoo()
    {
      object obj = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software", "foo", null);
      byte[] bytearray = (byte[])obj;
      foreach (byte b in bytearray)
        Console.WriteLine(b.ToString());
    }
