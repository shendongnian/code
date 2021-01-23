    string incoming = "doctor";
    // throws an exception if incoming isn't a member of TestEnum
    TestEnum foo = (TestEnum)Enum.Parse(typeof(TestEnum), incoming, true);
    TestEnum bar;
    if (Enum.TryParse(incoming, out bar))
    {
        // success
    }
    else
    {
        // incoming isn't a member of TestEnum
    }
