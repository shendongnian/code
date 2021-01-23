    public struct StructWithReferenceMember
    {
        private int[] intStoredAsReference;
        public StructWithReferenceMember(int asValue, int asReference)
            : this()
        {
            IntStoredAsValue = asValue;
            intStoredAsReference = new int[] { asReference };
        }
        public int IntStoredAsValue { get; set; }
        public int IntStoredAsReference
        {
            get { return intStoredAsReference[0]; }
            set { intStoredAsReference[0] = value; }
        }
    }
