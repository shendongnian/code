    class Class1 {
        public string ValueOfImportance { get; private set; }
        public void CalledMethod(string value) {
            ValueOfImportance = value; // possibly after processing the data from other calls
        }
    }
    class Class2 {
        public void CallerMethod() {
            Class1 obj; // you need to have the object reference of Class1
            string getStringSFromCalledMethod = obj.ValueOfImportance;
        }
    }
