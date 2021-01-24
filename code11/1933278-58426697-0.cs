    class A
    {
       protected object navLock = new object();
    
       protected virtual void Navigate()
       {
          lock(navLock)
          {
            //some stuff
          }
       }
    }
    class B: A
    {
        protected override void Navigate()
        {
           base.Navigate();
           lock(navLock) //Only if needed, cannot be around base.Navigate since it would result in dead lock
           {
             //some stuff
           }
        }
    }
