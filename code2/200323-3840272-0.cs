    class Bar
    {
        public string Name;
    }
    class Foo
    {
    private Bar _bar = new Bar();
    public Bar Bar
    {
      get { return _bar; }
      set { _bar = value; }
    }
    }
    class Program
    {
     static void Main(string[] args)
     {
      Foo foo = new Foo
      {
       Bar = { Name = "Hello"}
      };
     }
    }
