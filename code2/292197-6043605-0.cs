    public class Base
    {
        public virtual string DoSomething()
        {
            return "Base";
        }
    }
    internal sealed class Child : Base
    {
        public override string DoSomething()
        {
            return "Child";
        }
    }
