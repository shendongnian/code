    string incoming = "doctor";
    // throws an exception if the string can't be parsed as a TestEnum
    TestEnum foo = (TestEnum)Enum.Parse(typeof(TestEnum), incoming, true);
    // try to parse the string as a TestEnum without throwing an exception
    TestEnum bar;
    if (Enum.TryParse(incoming, true, out bar))
    {
        // success
    }
    else
    {
        // the string isn't an element of TestEnum
    }
    // ...
    enum TestEnum
    {
        Doctor, Mr, Mrs
    }
