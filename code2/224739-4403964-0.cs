    class C1 { 
      public virtual int ReadOnlyProperty { get; } 
    }
    class C2 { 
      public sealed override int ReadOnlyProperty { 
        get { return Property; }
      }
      public int Property {
        get { ... }
        set { ... }
      }
    }
