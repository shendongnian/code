    public static implicit operator Record(MaciRecord maci) 
    {
         return new Record
         {
             Id = maci.GetRecordId(),
             FirstName = Encoding.UTF8.GetString(maci.GetUserDataField("first_name")),
             LastName = Encoding.UTF8.GetString(maci.GetUserDataField("name"))
         };
    }
