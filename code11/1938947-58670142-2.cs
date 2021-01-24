    public class Test
    {
      private readonly int MyField = 10;
      private int MyProperty { get; }
      public Test()
      {
        MyProperty = 10;
      }
      public void Method()
      {
        var value1 = MyField;
        var value2 = MyProperty;
      }
    }
