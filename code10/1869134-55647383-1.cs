    abstract class A {
        protected A () {
            Test ();
        }
        protected virtual void Test () {
            Console.WriteLine ("2");
        }
    }
    class B : A {
        protected override void Test () {
            Console.WriteLine ("1");
            base.Test ();
        }
    }
    internal class Program {
        public static void Main (string [] args) {
            new B ();
        }
    }
