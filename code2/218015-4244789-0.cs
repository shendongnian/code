    using System;
    public class MyTestAttribute : Attribute {
        public MyTestAttribute() {
            Program.text = "world";
        }
    }
    class Program {
        public static string text = "hello";
        [MyTest]
        static void Main() {
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
