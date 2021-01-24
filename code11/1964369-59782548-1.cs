    class Option1
    {
        private readonly List<int> items;
        public IReadOnlyList<int> Items => items.AsReadOnly();
        public Option1()
        {
            this.items = ...;
        }
    }
    class Option2
    {
        private readonly List<int> items;
        public IReadOnlyList<int> Items { get; }
        public Option2()
        {
            this.items = ...;
            this.Items = this.items.AsReadOnly();
        }
    }
