    using (var connection = ...)
    {
        using (var context = new TestDataContext(connection, false))
        {
            ...
        }
    }
