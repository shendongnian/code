    public class Foo // Dummy reference type.
    {
      private readonly int value;
      public int Value { get { return value; } }
      public Foo (int value)
      {
        this.value = value;
      }
    }
    public class Bar
    {
      private Foo foo;
      
      public Bar(string unusedParameter) { }
      public Foo Foo // A complex property to be tested!
      {
        get { return foo; }
        set
        {
          if (value == null)
            throw new ArgumentNullException("value");
          if (value.Value < 0)
            throw new ArgumentOutOfRangeException();
          if (value.Value == 666)
            throw new ArgumentException("Inferno value strictly forbidden.");
          foo = value;
        }
      }
    }
