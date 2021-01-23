    class parent
    {
        public virtual bool equals(parent p)
        {
            Console.WriteLine("parent equals");
            return false;
        }
    
        public virtual bool notEquals(parent p)
        {
            return !this.equals(p);
        }
    }
    
    class child : parent
    {
        public override bool equals(parent p)
        {
            Console.WriteLine("child equals");
            return true;
        }
    }
