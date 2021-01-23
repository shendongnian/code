    class Person() : ICloneable
    {
        public string head;
        public string feet; 
        #region ICloneable Members
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
