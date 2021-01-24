    public static void TestMethodWrapper(int? x = 10, int? y = 20) {
        if ((x == null) && (y == null)) {
            return TestMethod();
        } else if (y == null) {
            return TestMethod(x);
        }
        return TestMethod(x, y);
    }
