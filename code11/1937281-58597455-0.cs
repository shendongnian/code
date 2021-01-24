    static class Conversions
    {
        public static Record ToRecord(this MaciRecord maci) => new Record
        {
            Id = maci.GetRecordId(),
            FirstName = Encoding.UTF8.GetString(maci.GetUserDataField("first_name")),
            LastName = Encoding.UTF8.GetString(maci.GetUserDataField("name"))
        };
    }
