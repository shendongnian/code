    using N;
    namespace N2
    {
        class A : AI
        {
            BI property1;
            BI Property1 { get { return property1; } }
    
            public A() 
            {
                property1 = new B();
            }
        }
        
        class B : BI
        {
            int Property2 { get { return 2; } }
            int Property3 { get { return 3; } }
        }
    }
