    class A
    {          
       protected virtual void Navigate()
       {
          //some stuff          
       }
    }
    class B: A
    {
        protected object navLock = new object();
        protected override void Navigate()
        {
           lock(navLock) 
           {
             base.Navigate();
           
             //some stuff
           }
        }
    }
