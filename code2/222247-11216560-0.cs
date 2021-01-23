    using System;
    
    namespace return_type_covariance
    {
        public interface A1{} 
        public class A2 : A1{}
        public class A3 : A1{}
        
        public interface B1 
        {
            A1 theA();
        }
        
        public class B2 : B1
        {
            public A1 theA()
            {
                return new A2();
            }
        }
        
        public static class B2_ReturnTypeCovariance
        {
            public static A2 theA_safe(this B2 b)
            {
                return b.theA() as A2;    
            }
        }
        
        public class B3 : B1
        {
            public A1 theA()
            {
                return new A3();    
            }
        }
        
        public static class B3_ReturnTypeCovariance
        {
            public static A3 theA_safe(this B3 b)
            {
                return b.theA() as A3;    
            }
        }
        
        public class C2
        {
            public void doSomething(A2 a){}    
        }
        
        class MainClass
        {
            public static void Main (string[] args)
            {
                var c2 = new C2();
                var b2 = new B2();
                var a2=b2.theA_safe();
                
                c2.doSomething(a2);
            }
        }
    }
