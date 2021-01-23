    public class MyClass 
    {
        static int i=0;
        class A
        {         
            public A()
            {
    
            }
        }
    
        public static void Run()
        {
            // Declare array to hold instances
            A[] instances;
            // instances is now five elements long
            instances = new A[5];
            for (int j=0;j<5;j++)
            {
                //Initialize Instance
                instances[j] = new A();
            }
        }
    }
