    class MyObject
    {
        public string SomeProperty { get; set; }
        public MyObject(IDataReader reader)
        {
            SomeProperty = reader.GetString(0);
            // - or -
            SomeProperty = reader.GetString(reader.GetOrdinal("SomeProperty"));
            // etc.
        }
    }
