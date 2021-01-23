    class BaseClass
    {
        public virtual string SayHi()
        {
            return ("Hi");
        }
    }
    
    class DerivedClass : BaseClass
    {
        public override string SayHi()
        {
            return (base.SayHi() + " from derived");
        }
    }
