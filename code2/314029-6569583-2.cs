    class myClass : ICloneable
    {
        public String test;
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
