    namespace MyMultivaluedUniverse
    {
        // As these classes are static, all methods and properties need to be static too.
        public static class MyUniverse 
        {
            public static double A { get; set; } // shortcut notation for properties .NET 2+
            public static double B { get; set; }
    
            public static double Add() // If you are just adding your Properties A and B, no need for this method to have parameters
            {
                return A + B;
            }
        }
    
        public static class MyWorld
        {
            public static double E { get; set; }
            public static double Subtract(double D)
            {
                E = D - MyUniverse.Add(); // Note how I specify the class name before the method:  this works only for static methods
                return E;
            }
        }
    
        // This class is not static, so doesn't need static everywhere
        public class MyHome
        {
            public double Arithmetic(double F)
            {
                return MyUniverse.Add() - MyWorld.Subtract(F); // will trivially equal F
            }
        }
    
        public class MySelf
        {
            MyHome mh = new MyHome(); // shows how to instantiate a non static class and use it
            public double DoWork(double G)
            {
                return mh.Arithmetic(G); // I precede the method name with the Instance name.
            }
        }
    }
