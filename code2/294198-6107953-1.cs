    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct Test
    {
        public int _A, _B;
        public int B
        {
            get { return _B; }
            set { _B = value; }
        }
        public int A
        {
            get { return _A; }
            set { _A = value; }
        }
    }
    Test _Test;
    [Category("MyCategory")]
    public Test TestProperty
    {
        get { return _Test; }
        set { _Test = value; }
    }
    
