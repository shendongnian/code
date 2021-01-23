     [Foo]
     class Other
     {
        
     }
    
     [Foo]
     class Other2
     {
     }
     [System.Serializable]
     sealed class FooAttribute : CodeAccessSecurityAttribute
     {
          public FooAttribute(SecurityAction action = SecurityAction.Demand) : base(action) { }
          public override System.Security.IPermission CreatePermission() { return null; }        }
    
     [Foo]
     class Program
     {
           
      static void Main(string[] args) {}
     }
        
