    Assembly1.dll:
        namespace test {
            internal class InternalClass {
            }
   
            public class PublicClass { 
            }
        } 
    
    Assembly2.dll:
        using test;
        ...
        InternalClass c1; // Error
        PublicClass c2; // OK
