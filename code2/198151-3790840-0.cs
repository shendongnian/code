    class HierarchyBase
    {
        public int A { get; set; }
        public bool Validate()
        {
            return this.OnValidate();
        }
        protected virtual bool OnValidate()
        {
            return (this.A % 2 == 0);
        }
    }
