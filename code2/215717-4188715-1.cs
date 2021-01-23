    class Foo {
        public int i { get; set; }
 
        public int Multiply (int j) {
            return i * j;
        }
        public int Add (int j) {
            return i + j;
        }
    }
    class Program {
        static void Main (string [] args) {
            Func<Foo, int, int> multiply = (Func<Foo, int, int>)Delegate.CreateDelegate(typeof(Func<Foo, int, int>), null, typeof(Foo).GetMethod("Multiply");
            Func<Foo, int, int> add = (Func<Foo, int, int>)Delegate.CreateDelegate(typeof(Func<Foo, int, int>), null, typeof(Foo).GetMethod("Add");
            var foo1 = new Foo { i = 7 };
            var foo2 = new Foo { i = 8 };
            Console.Write ("{0}\n", multiply(foo1, 5));
            Console.Write ("{0}\n", add(foo1, 5));
            Console.Write ("{0}\n", multiply(foo2, 5));
            Console.Write ("{0}\n", add(foo2, 5));
            Console.ReadKey ();
        }
    }
