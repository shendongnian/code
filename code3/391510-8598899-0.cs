    public class Base
    {
        public static string str = null;
        static Base()
        {
            str = "hello";
            Console.WriteLine("Ctor cald");
        }
    }
    public class Derived1 : Base { }
    public class Derived2 : Base { }
    
   
     public class MainClass {
        public static void Maim()
    {
       Derived1 der1 = new Derived1();
       Derived2 der2 = new Derived2();
    }
    
    }
