    class Base { 
    }
    class Derived : Base { 
    }
    class Something {
        private void DoSomething(Base b) {
            Console.WriteLine("DoSomething - Base");
        }
        private void DoSomething(Derived d) {
            Console.WriteLine("DoSomething - Derived");
        }
        public void Test() {
            var d = new Derived();
            DoSomething(d);
        }
    }
    static class Program {
        static void Main(params string[] args) {
            Something something = new Something();
            something.Test();
        }
    }
