    int i = 10;
    string s1 = i.ToString(); // OK
    string s2 = (string)i;    // Compile error.
    object o = 10;
    string s3 = o.ToString(); // OK
    string s4 = (string)o;    // Runtime error.
