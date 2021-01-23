    public class A {
        public int Method(int arg1) {
             // ....
        }
    }
    Func<A, int, int> methodDelegate = Delegate.CreateDelegate(typeof(Func<A, int, int>), null, typeof(A).GetMethod("Method"));
    A a1 = new A();
    A a2 = new A();
    int val1 = methodDelegate(a1, 5);
    int val2 = methodDelegate(a2, 6);
