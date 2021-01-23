    string incoming = "doctor";
    // throws an exception if "incoming" isn't an element of TestEnum
    TestEnum foo = (TestEnum)Enum.Parse(typeof(TestEnum), incoming, true);
    // try to parse "incoming" into a TestEnum without throwing an exception
    TestEnum bar;
    if (Enum.TryParse(incoming, out bar))
    {
        // success
    }
    else
    {
        // incoming isn't an element of TestEnum
    }
    // ...
    enum TestEnum
    {
        Doctor, Mr, Mrs
    }
