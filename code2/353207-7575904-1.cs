    class DWF
    {
        static IEnumerable<Fact> defaultAllowedFacts = new Fact[] { ... }
        IEnumerable<Fact> allowedFacts;
        public DWF() : this(defaultAllowedFacts) { ... }
        internal DWF(IEnumerable<Fact> allowed)
        {
            // for testing only, perhaps
            this.allowedFacts = allowed;
        }
        ...
    }
