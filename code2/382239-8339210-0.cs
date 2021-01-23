    public class A
        {
            public static void method()
            {
                Console.WriteLine("method in base class");  
            }
        public class B
        {
            public void bmethod()
            {
                A.method(); 
            }
        }
    }
    public class C : A.B
    {
        public void cmethod()
        {
            bmethod(); 
        }
    }
