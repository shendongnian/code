    class BaseClass
    {
        public string SayHi()
        {
            return ("Hi");
        }
    }
    
    class DerivedClass : BaseClass
    {
        public new string SayHi()
        {
            return (base.SayHi() + " from derived");
        }
    }
