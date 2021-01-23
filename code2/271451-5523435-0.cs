    public static void GetTestClass(TestClass tc, string name) {
        ...
        tc = new TestClass();
        ...
    }
    static void Main() {
        TestClass tc = null;
        GetTestClass(tc, "Some Name");
        // The assignment to tc in GetTestClass doesn't affect the tc variable in Main.
        ...
    }
