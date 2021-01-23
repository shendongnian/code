    public class Base
    {
        protected virtual string WhoAmI()
        {
            return "Base";
        }
    }
    public class Derived : Base
    {
        public new virtual string WhoAmI()
        {
            return "Derived";
        }
    }
    public class AnotherDerived : Derived
    {
        public override string WhoAmI()
        {
            return "AnotherDerived";
        }
    }
