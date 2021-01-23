    struct Test
    {
        public Test(string name, string oldValue, string newValue)
            : this()
        {
            AssayName = name;
            OldUnitName = oldValue;
            NewUnitName = newValue;
        }
        public string AssayName { get; private set; }
        public string OldUnitValue { get; private set; }
        public string NewUnitValue { get; private set; }
    }
