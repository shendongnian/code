    namespace CastTest
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
    
                A a = new A();
                B b = Cast.To<B>(a);
                b.Test();
                
                Console.Write("Done.");
                Console.ReadKey();
            }
    
            public class Cast
            {
                public static T To<T>(dynamic o)
                {
                    return (T)o;
                }
            }
    
            public class A
            {
                public static explicit operator B(A a)
                {
                    return new B();
                }
            }
    
            public class B
            {
                public void Test()
                {
                    Console.WriteLine("It worked!");
                }
            }
    
        }
    }
