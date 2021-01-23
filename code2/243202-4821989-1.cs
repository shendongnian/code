    ISomething Sample() {
        Something s1 = new Something();
        s2.DoSomething(); // Assuming s is the only reference to s, then it no longer is
                          // rooted after this expression
        Something s2 = new Something();
        ISomething is1 = s2;
        s2 = null;
        is1.DoSomething(); // The reference remains valid and the lifetime of the
                           // object created continues until we release all
                           // remaining references to it.
        return is1;
    }
