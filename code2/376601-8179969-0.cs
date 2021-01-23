    public void run()
    {
      foo f = new foo();
      Type t = typeof(foo);
      foreach (FieldInfo info in t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
         info.SetValue(f, "foobar");
      }
    }
