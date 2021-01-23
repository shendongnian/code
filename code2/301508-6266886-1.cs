    void test(object p) {
        if (p == null)
            return; // Could be anything
        int? i = p as int?;
        if (i != null) {
            // p is an int?
            return;
        }
        bool? b = p as bool?;
        if (b != null) {
            // p is an bool?
            return;
        }
    }
