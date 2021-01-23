    public class Base
    {
        public virtual string Info { get { return "From Base"; } }
    }
    public class A : Base
    {
        public override string Info { get { return "From A"; } }
    }
