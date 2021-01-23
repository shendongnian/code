    public class MyKey
    {
        private readonly SomeEnum enumeration;
        private readonly int number;
        public MyKey(SomeEnum enumeration, int number)
        {
            this.enumeration = enumeration;
            this.number = number;
        }
        public int Number
        {
            get { return number; }
        }
        public SomeEnum Enumeration
        {
            get { return enumeration; }
        }
        public override int GetHashCode()
        {
            int hash = 23 * 37 + this.enumeration.GetHashCode();
            hash = hash * 37 + this.number.GetHashCode();
            return hash;
        }
        public override bool Equals(object obj)
        {
            var supplied = obj as MyKey;
            if (supplied == null)
            {
                return false;
            }
            if (supplied.enumeration != this.enumeration)
            {
                return false;
            }
            if (supplied.number != this.number)
            {
                return false;
            }
            return true;
        }
    }
