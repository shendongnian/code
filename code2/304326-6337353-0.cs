    class TypeA
    {
        private TypeB _b;
        public TypeB B
        {
            get { return (TypeB)_b.Clone(); }
            set { _b = value; }
        }
    }
