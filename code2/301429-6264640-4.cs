    class FooFactory {
    
      readonly Type type;
      
      public FooFactory(Type type) {
        this.type = type;
        DisplayName = ((FooAttribute) Attribute.GetCustomAttribute(
          type,
          typeof(FooAttribute))
        ).DisplayName;
      }
      
      public String DisplayName { get; private set; }
      
      public Object CreateFoo() {
        return Activator.CreateInstance(this.type);
      }
      
      public override String ToString() {
        return DisplayName;
      }
      
    }
