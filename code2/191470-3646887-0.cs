    // Generated Code
    public partial Class1
    {
      public string Foo { get { ... } }
    }
    
    // Your Code
    public interface IClass1
    {
      [MyAttribute]
      public string Foo { get; }
    }
    
    public partial Class1 : IClass1
    {
    }
