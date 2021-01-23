    public interface IFooable
    {
        void Foo();
    }
    // ...
    public class Foo<T> where T : IFooable
    {
        private T _t;
        // ...
        public void DoFoo()
        {
            _t.Foo();  // works because we constrain T to IFooable.
        }
    }
