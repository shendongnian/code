    public class Father
    {
        protected readonly Int32 field;
    
        protected Father (Int32 field)
        {
            this.field = field;
        }
    }
    
    public class Son : Father
    {
        public Son() : base(5)
        {
    
        }
    }
