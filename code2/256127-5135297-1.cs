    public abstract class A<T> where T : A, new()
    {
        public void f()
        {
            A bOrC = new T();
        }
        public abstract void f2();
    }
    public class B : A<B> {
        public override void f2(){}
    }
    public class C : A<C> {
        public override void f2(){}
    }
