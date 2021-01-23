    public class Base : IInterface
    {    
       protected virtual void Method()
       {
         
       }
       void IInterface.Method()    
       {        
           this.Method()
       }
     }
     public class Derived : Base
     {
         protected override void Method()
         {
         }
     }
