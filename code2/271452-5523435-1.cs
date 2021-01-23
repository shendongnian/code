    public static TestClass GetTestClass(string name) {
        ...
        TestClass tc = new TestClass();
        ...
        return tc;
    }
    static void Main() {
        TestClass tc = GetTestClass("Some Name");
        ...
    }
