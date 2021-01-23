    public abstract class NamedFoo
    {
        private readonly string name;
        public string Name { get { return name; } }
        protected NamedFoo(string name)
        {
            this.name = name;
        }
    }
    public class DerivedFooWithConstantName
    {
        public DerivedFooWithConstantName() : base("constant name")
        {
        }
    }
