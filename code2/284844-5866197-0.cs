        public TestClass(ref String passedStr)
        {
            passedStr = "Change me";
        }
        ...
        TestClass obj = new TestClass(ref aString);
