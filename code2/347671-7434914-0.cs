    namespace A
    {
       delegate void X(int i); //allowed
       public class B
       {
             delegate void Y(int i); //also allowed
       }
    }
