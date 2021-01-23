    using A;
    namespace B
    {
         public class BClass
         {
             // don't actually need "A" qualifier here as we're "using A" above, this is just for clarity
             private A.AClass aClass_ = new A.AClass();
             
             // ctor
             public BClass()
             {
                 aClass_.AMethod();
             }
         }
    }
