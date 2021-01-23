    class A
    {
        public string PropA {set; get;}
        public A()
        {
        }
    
        protected virtual PropertyInfo[] GetProperties()
        {
            return this.GetType().GetProperties(BindingFlags.Public);
        } 
    }
    class B : A
    {
        public string PropB {set; get;}
    
        public B() : base()
        {
        }
        public new PropertyInfo[] GetProperties()
        {
            return this.GetType().GetProperties(BindingFlags.Public);
        }
    }
    var b = new B();
    var prop = b.GetPropeties();
