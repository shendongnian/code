    void Main()
    {
        var foo = new Foo();
        foo[1] = "Foo1";	
        //foo.Dump();
    }
    
    public class Foo
    {
        public string Foo1 {set;get;}
        public string Foo2 {set;get;}
        public string Foo3 {set;get;}
        public string Foo4 {set;get;}
        public string Foo5 {set;get;}
        public string Foo6 {set;get;}
        public string Foo7 {set;get;}
        public string Foo8 {set;get;}
        public string Foo9 {set;get;}
        
        public string this[int index]
        {
            get
            {
                return getPropertyValue(index);
            }
            set
            {
                setPropertyValue(index, value);
            }
        }
        private void setPropertyValue(int i, string value)
        {
           var propi = this.GetType().GetProperty("Foo" + i);
           if (propi != null)
              propi.SetValue(this,value,null);
        }
        private string getPropertyValue(int i)
        {
            var propi = this.GetType().GetProperty("Foo" + i);
            if (propi != null)
                return (string)propi.GetValue(this, null);
            return null;
        }
    }
