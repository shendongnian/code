    public CustomAttribute : Attribute
    {
      public CustomAttribute(string propertyName)
      {
        this.PropertyName = propertyName;
      }
      
      public string PropertyName { get; private set; }
    }
    public class MyClass
    {
      [Custom("MyProperty")]
      public int MyProperty { get; set; }
    }
