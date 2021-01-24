    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                A[] test = new A[2];
                test[0] = new B();
                test[0].Example();
                (test[0] as B).Example1();
            }
            public class A
            {
                public void Example()
                {
    
                }
            }
            class B : A
            {
                public void Example1()
                {
    
                }
            }
        }
    }
