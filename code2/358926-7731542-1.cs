    struct Test 
    { 
        public string AssayName { get; set; } 
        public string OldUnitName { get; set; } 
        public string NewUnitName { get; set; } 
 
        public Test(string name, string oldValue, string newValue) : this()
        { 
            AssayName = name; 
            OldUnitName = oldValue; 
            NewUnitName = newValue; 
        } 
    } 
