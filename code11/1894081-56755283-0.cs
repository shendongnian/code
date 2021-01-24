    abstract class Base
    {
        protected abstract void Initialize();
    }
    class Derived : Base
    {
        protected Derived() { /* ... */}
        protected override void Initialize() { /* ... */}
        public Derived CreateDerived()
        {
            var derived = new Derived();
            derived.Initialize();
            return derived;
        }
    }
