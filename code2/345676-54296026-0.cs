    namespace adonet.extensions
    {
      public static class AdonetExt
      {
        public static int GetInt32(this SqlDataReader reader, string columnName)
        {
          return reader.GetInt32(reader.GetOrdinal(columnName));
        }
      }
    }
