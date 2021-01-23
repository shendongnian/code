    class Program
    {
        delegate void MyDelegate();
    
        static void Main()
        {            
            //Notice how we use the same delegate instance
            //to target different methods of the same signature
    
            MyDelegate myDelegate = new MyDelegate(MethodA);
            myDelegate(); //Invoke the method
            myDelegate = MethodB;
            myDelegate();
            myDelegate = MyClass.MethodZ;
            myDelegate();
    
            Console.ReadLine();
        }
    
        static void MethodA()
        {
            Console.WriteLine("Method 'A' is doing work.");
        }
    
        static void MethodB()
        {
            Console.WriteLine("Method 'B' is doing work.");
        }
    
        class MyClass
        {
            public static void MethodZ()
            {
                Console.WriteLine("Method 'Z' of MyClass is doing work");
            }
        }
    }
