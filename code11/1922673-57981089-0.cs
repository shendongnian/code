    public interface IPersistenceLayer
    {
        // These methods could all be called 'Foo' without the 'A' 'B' or 'C' suffix, but I've appended it to make it clear which method is being called
        void FooB(B b);
        void FooC(C c);
        void FooD(D d);
    }
    // I've made 'A' abstract, because in your example there is no 'Foo(A a)' method so this can't provide a default 'Foo' implementation
    public abstract class A
    {
        public abstract void Foo(IPersistenceLayer persistenceLayer);
    }
    public class B : A
    {
        public override void Foo(IPersistenceLayer persistenceLayer) => persistenceLayer.FooB(this);
    }
    public class C : A
    {
        public override void Foo(IPersistenceLayer persistenceLayer) => persistenceLayer.FooC(this);
    }
    public class D : A
    {
        public override void Foo(IPersistenceLayer persistenceLayer) => persistenceLayer.FooD(this);
    }
    public static class PersistenceLayerExtensions
    {
        public static void Foo(this IPersistenceLayer persistenceLayer, A a) => a.Foo(persistenceLayer);
    }
    class Program
    {
        public static void Main(string[] args)
        {
            List<A> alist = new List<A>
            {
                new B(),
                new C(),
                new D()
            };
            PersistenceLayer persistenceLayer = new PersistenceLayer();
            foreach (A a in alist)
            {
                 persistenceLayer.Foo(a);
            }
        }
    }
