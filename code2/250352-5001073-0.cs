    public struct Rule
    {
        public Predicate<MyCustomType> Test;
        public string Key;
        public Rule(Predicate<MyCustomType> test, string key) : this()
        {
            this.Test = test;
            this.Key = key;
        }
    }
