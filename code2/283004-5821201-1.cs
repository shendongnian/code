    class MyClass 
    {
         readonly object locker = new object();
         bool done = false;     
         public void DoSomething()     
         {         
            if (!done)
            {
                lock(locker)
                {
                    if(!done)
                    {
                        done = true;
                        ReallyDoSomething();
                    }
                }
            }
        }
        int x;
        void ReallyDoSomething()
        {
            x = 123;
        }
        void DoIt()
        {
            DoSomething();
            int y = x;
            Debug.Assert(y == 123); // Can this fire?
        }
                
