    public abstract class A {
        public abstract void Test();
    }
    public class B : A {
        public override void Test() {
            System.Console.WriteLine("B:Test called!");
        }
    }
    public class C : A {
        public override void Test() {
            System.Console.WriteLine("C:Test called!");
        }
    }    
    class Program {
        private A _concrete;
        public Program(A concrete) {
            _concrete = concrete;
        }
        public void DoTest() {
            _concrete.Test();
        }
        static void Main(string[] args) {
            Program pb = new Program(new B());
            pb.DoTest();
            Program pc = new Program(new C());
            pc.DoTest();
        }
    }
}
