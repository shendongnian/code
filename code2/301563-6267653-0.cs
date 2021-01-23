    class Base {
        private readonly string baseName;
        public string BaseName { get { return this.baseName; } }
        public Base(string baseName) { this.baseName = baseName; }
    }
    class Derived : Base {
        private readonly string derivedName;
        public string DerivedName { get { return this.derivedName; } }
        public Derived(string baseName, string derivedName) : base(baseName) {
            this.derivedName = derivedName;
        }
    }
