    class HierarchyBase<T>
        where T : HierarchyBase<T>
    {
        protected readonly List<Func<T, bool>> validators;
        public HierarchyBase()
        {
            validators = new List<Func<T, bool>>();
            validators.Add(x => x.A % 2 == 0);
        }
        public int A { get; set; }
        public bool Validate()
        {
            return validators.All(validator => validator((T)this));
        }
    }
