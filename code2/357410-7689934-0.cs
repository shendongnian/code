      public static class MyStaticClass
        {
            public static int DoIntWork(string i)
            {
                //for example only
                return 0;
            }
        }
    
        public class A
        {
            public A(int i)
            {
            }
        }
    
        public class B : A
        {
            public B(string x) : base(MyStaticClass.DoIntWork(x))
            {
            }
        }
