    public class Exposer : A, B
    {
        void A.Do_A() { ; }
        void B.Do_B() { ; } 
    }
    public void Main() 
    {
         // the casts are now required;
         // otherwise, you'll get a compiler error
         // telling you that the method is inaccessible
         ((A)Exposer).Do_A(); 
         ((B)Exposer).Do_B(); 
    } 
