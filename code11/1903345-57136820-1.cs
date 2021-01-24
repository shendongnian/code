 c#
// brain.cs
namespace Brain {
   public class A {
      public B InstanceOfB { get; set;}
   }
   public class B { }
}
This will still work if the two classes are in separate files, so the above is the same as:
 c#
/// brain.A.cs
namespace Brain {
   public class A {
      public B InstanceOfB { get; set;}
   }
}
/// brain.B.cs
namespace Brain {
   public class B { }
}
Ultimately you just need to add the using statement for the namespace they use in their code when adding the files to your project (`using Brain;` for the example above). 
