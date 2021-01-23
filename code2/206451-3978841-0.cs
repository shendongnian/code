    class A: IDisposable
    {
        public A() // constructor
        {
            r1 = new Resource(res1_id);     // resource aquisition 
            r2 = new Resource(res2_id);     // assume exception here
        }
    
        public void Dispose()
        {
            r1.Release();           // released successfully
            r2.Release();           // what to do?
        }
    
        Resource r1, r2;
    }
