     class MyClass: IComparable
    {
        
        public int value { get; set; }
        #region IComparable Members
        public int CompareTo(object obj)
        {
            MyClass e = (MyClass)obj;
            int r;
            r = this.value.CompareTo(e.value);
            return r;
        }
        #endregion
    }
