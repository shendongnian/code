    public abstract class A {
        public string sayHi() { return "hi"; } // a method with code in it
        public abstract string sayHello();  // no implementation
    }
    public class B 
       : A
    {
        // must implement, since it is not abstract
        public override string sayHello() { return "Hello from B"; }
    }
