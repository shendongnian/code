    short s = 1;
    int i = s;
    MyMethod(s); // Generic
    MyMethod(i); // int
    MyMethod((int)s); // int
    MyMethod(1); // int
    MyMethod<int>(1); // Generic**
    MyMethod(1.0); // Generic
    // etc.
