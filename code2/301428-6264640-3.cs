    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    sealed class FooAttribute : Attribute {
    
      public FooAttribute(String displayName) {
        DisplayName = displayName;
      }
      
      public String DisplayName { get; private set; }
      
    }
