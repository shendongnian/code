    class Program {
        static void Main(string[] args) {
            Foo myFoo = new Foo();
            //myFoo.OldMethod(); //Cannot be called
            myFoo.NewMethod();
            //Invocation through reflection (ugly but works also with foreign code)
            myFoo.GetType().GetMethod(nameof(Foo.OldMethod)).Invoke(myFoo, null);
            //Invocation through special interface (nicer but works only with own code)
            ((ILegacyFoo)myFoo).OldMethod();
        }
    }
    public interface ILegacyFoo {
        void OldMethod();
    }
    public class Foo 
        : ILegacyFoo {
        [Obsolete("Use NewMethod() instead.", true)]
        public void OldMethod() {
            OldMethodImplementation();
        }
        public void NewMethod() {
            Console.Out.WriteLine("New code called...");
        }
        private void OldMethodImplementation() {
            //Do something
            Console.Out.WriteLine("Old code called...");
        }
        void ILegacyFoo.OldMethod() {
            OldMethodImplementation();
        }
    }
