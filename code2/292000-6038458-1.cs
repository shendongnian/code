    struct OtherClass
    {
        public int XYZ { get; }
        public OtherClass(int xyz)
        {
             XYZ = xyz;
        }
        public OtherClass AddToXYZ(int count)
        {
             return new OtherClass(this.XYZ + count);
        }
    }
