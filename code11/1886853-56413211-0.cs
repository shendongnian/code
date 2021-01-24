    using System;
    
    class test {
        public static double height = 1.82; // meters
        public static void grow(double rate) {
            height += rate;
        }
    }
    
    class MainClass {
        public static void Main(string[] args) {
            test.grow(0.05);
            double height = test.height;
            Console.WriteLine($"New height: {height}");
        }
    }
