    public class Parent
    {
        public virtual void Foo()
        {
        }
    }
    
    public class Child : Parent
    {
        // call constructor in the current type
        public Child() : this("abc")
        {
        }
    
        public Child(string id)
        {
        }
    
        public override void Foo()
        { 
            // call parent method
            base.Foo();
        }
    }
