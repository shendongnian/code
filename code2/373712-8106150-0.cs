    class Program {
        public static void Main() {
            dynamic d = 1.0;
            MyMethod(d);
        }
        public void MyMethod(int i) {
            Console.WriteLine("int");
        }
        public static void MyMethod(double d) {
            Console.WriteLine("double");
        }
    }
