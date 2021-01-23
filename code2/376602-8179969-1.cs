    public void run()
    {
      foo f = new foo();
      Type t = typeof(foo);
      foreach (PropertyInfo info in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
         info.SetValue(f, "foobar", new object[0]);
      }
    }
