    public class ChildClass : BaseClass, intf
    {
        public override string Hello()
        {
            return "Hello of child class called";
        }
    }
    public class BaseClass
    {
        public virtual string Hello()
        {
            return "Hello of base class called";
        }
    }
