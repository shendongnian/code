    public class ClassB { /* Class to be lazily instantiated */ }
    public abstract class BaseA
    {
        private Lazy<ClassB> _b = new Lazy<ClassB>(() => new ClassB());
        public virtual ClassB B { get { return _b.Value; } }
    }
    public class ClassA : BaseA
    {
        public override ClassB B { get { return base.B; } }
    }
