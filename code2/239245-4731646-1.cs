    namespace N
    {
       public class A {}
       public class B {}
    }
    namespace N
    {
       using A = System.IO;
       class X
       {
          A.Stream s1;         // Error, A is ambiguous
          A::Stream s2;        // Ok
       }
    }
