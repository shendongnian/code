    class Foo
    {
        public string Bar { get; set; }
        
        public override int GetHashCode()
        {
            return this.Bar.GetHashCode();
        }
    
        public override bool Equals(object other)
        {
            Foo otherFoo = other as Foo;
            if (otherFoo == null)
                return false;
            else
                return this.Bar == otherFoo.Bar;
        }
    }
