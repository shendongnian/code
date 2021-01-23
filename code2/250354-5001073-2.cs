    class Rule
    {
        private readonly Predicate<MyCustomType> _test;
        private readonly string _key;
        public Predicate<MyCustomType> Test { get { return _test; } }
        public string Key { get { return _key;  } }
        public Rule(Predicate<MyCustomType> test, string key)
        {
            _test = test;
            _key = key;
        }
    }
