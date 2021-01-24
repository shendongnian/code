    yield return reader.GetAddress();
    public static class ReaderExtensions
    {
        public static Address GetAddress(this SqlDataReader reader)
        {
            return new Address { ID = (int)reader["ID"], Address = reader["Address"].ToString(), PhoneNumber = (int)reader["PhoneNumber"] };
        {
    }
