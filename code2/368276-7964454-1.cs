     public interface IA
     {
     }
    
     public class B
     {
     }
    
     public class C
     {
     }
     public void SomeMethod( B b )
     {
         IA o1 = (IA) b;   <-- will compile
         C o2 = (C)b;  <-- won't compile
     }
