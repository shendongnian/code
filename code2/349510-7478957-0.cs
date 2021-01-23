    class Program {      
        static void Main(string[] args) {
            dynamic x = new { Foo = 12, Bar = "twelve" };
            Display(x);
        }
        static void Display(dynamic x) {
            Console.WriteLine(x.Foo);
            Console.WriteLine(x.Bar);
        }
    }
