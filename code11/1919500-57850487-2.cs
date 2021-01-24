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
    myClass instance= new myClass();
    instance.DoSomething();
    myClass.b = "another world";
    instance.B = "C# world";
