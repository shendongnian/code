    public class OuterClass
    {
        public OuterClass{console.writeln("OuterClaass Called");}
      
      public class NestedClass //it dosent Inherit
      {
        public NestedClass{console.writeln("NestedClass Called");}
      }
    }
    static void Main()
    {
            
      OuterClass.NestedClass nestedobject = new OuterClass.NestedClass();
    }
