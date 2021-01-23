    public class MyClass
    {
        static A[] instances;
    
        class A
        {
            public A()
            { 
    
            }
        }
    
        public static void Run()
        {
            instances = new A[5];
            for (int j=0;j<5;j++)
            {
                instances[j] = new A();
            }
        }
    }
