    public class Base<T>
        {
            public static string str = null;
    
            static Base()
            {
                str = "hello";
    
                Console.WriteLine("Ctor cald");
            }
        }
    
        public class Derived1<T> : Base<T>{}
        public class Derived2<T> : Base<T> { }
    
        public partial class Program
        {
             public static void Main()
            {
                Derived1<int> derv = new Derived1<int>();
                Derived2<double> derv2 = new Derived2<double>();
                Derived2<double> derv3 = new Derived2<double>();
                   
                
                Console.ReadKey();
            }      
        }  
