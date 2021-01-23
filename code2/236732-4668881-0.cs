    namespace DelegatePrac
    {   
        public delegate void One(int a, int b); 
        
        public class Some
        {
            public static void Add(int a, int b)
            { 
                int c = a + b;    Console.WriteLine("{0}",c);
            }
           
            public static void Subtract(int a, int b)
            { 
                int c = a - b;  Console.WriteLine("{0}",c);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                One o1,o2;
                o1 = Some.Add;//gives error here
                o2 = Some.Subtract;//and here!!
                o1(33,44);
                o2(45, 15);
                Console.ReadLine();
            }
        }
    }
