    abstract class A {
        protected A () {
            BeforeTest ();
            Test ();
        }
        protected abstract void BeforeTest ();
        private void Test () {
            Console.WriteLine ("2");
        }
    }
    class B : A {
        protected override void BeforeTest () {
            Console.WriteLine ("1");
        }
    }
    internal class Program {
        public static void Main (string [] args) {
            new B ();
        }
    }
