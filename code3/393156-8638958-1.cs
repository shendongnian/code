    private class Test 
    {
        public Test()
        {
            Id = Guid.NewGuid();
            //items = new List<string>();
        }
        public Guid Id { get; set; }
        private Lazy<List<string>> _items = new Lazy<List<string>>();
        public List<string> items 
        { 
            get { return _items.Value; }
        }
    }
