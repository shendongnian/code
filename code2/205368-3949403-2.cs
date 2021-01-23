    public class Program
    {
        bool SomeFunction()
        {
    
        Base baseref = null;
    
         switch(DateTime.Now.Second)
         {
           case 1:
            baseref = Base.Create<Derived1>();  // OK
           break;
    
           case 2:
            baseref = Base.Create<Derived2>();  //OK
            break;
    
           case 60:
            baseref = Base.Create<string>(); //COMPILE ERR - good because string is not a derived class
            break;
         }
    
         // pass baseref somewhere     
        }
    }
