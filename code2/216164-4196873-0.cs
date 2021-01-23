    public class A
    {
        public virtual string Name(string name)
        {
            return name;
        }
    }
    public class B : A
    {
        public override string Name(string name)
        {
            return base.Name(name); // calling A's method
        }
    }
    public class C : A
    {
        public override string Name(string name)
        {
            return "1+1";
        }
    }
