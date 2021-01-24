    class myClass
    {
      public string a = "hello";
      static public string b = "world";
      public string B { get { return b; } set { b = value; } }
      public void DoSomething()
      {
        b = "new world";
      }
    }
