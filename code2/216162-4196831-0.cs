    class Base
    {
        public virtual string Name
        {
            get { return "BaseName"; }
        }
    }
    class Derived : Base
    {
        public override string Name
        {
            get { return "Derived"; }
        }
    }
