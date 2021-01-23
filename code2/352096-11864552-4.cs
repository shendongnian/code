        public class OuterClass
    {
        public OuterClass{console.writeln("OuterClaass Called");}
      
      public class NestedClass : OuterClass //It does Inherit
      {
        public NestedClass{console.writeln("NestedClass Called");}
      }
    }
    static void Main()
    {
      outerClass.NestedClass nestedobject = new outerClass.NestedClass();
    }
   
