    class Scope
    {
        int x;
    
        int f() => x; // x is not const member
    
        void g()
        {
            new gImpl(f()).Run();
        }
    
        class gImpl
        {
            readonly int readOnlyVar;
            public gImpl(
                int readOnlyVar)
            {
                this.readOnlyVar = readOnlyVar;
            }
            public void Run()
            {
                // Some code in which I want to restrict access to readOnlyVar to read only 
    
                // error CS0191: A readonly field cannot be assigned to (except in a constructor or a variable initializer)
                readOnlyVar = 3;
            }
        }
    }
