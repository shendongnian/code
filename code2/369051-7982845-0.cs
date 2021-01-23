    public interface IFoo<out T> {
    }
    public interface IBar {
        IFoo<IBar> Foo { get; set; }
    }
    public class Foo<T> : IFoo<T> where T : IBar, new() {
        private readonly T _bar;
        public Foo() {
            _bar = new T { Foo = (IFoo<IBar>)this };
        }
    }
    class Bar : IBar {
        public IFoo<IBar> Foo { get; set; }
    }
    public static class Program {
        public static void Main(params string[] args) {
            Bar b = new Bar();
            Foo<Bar> f = new Foo<Bar>();
        }
    }
