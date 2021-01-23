      public static class DataRowExtensions
      {
        public static T FieldOrDefault<T>(this DataRow row, string columnName)
        {
          return row.IsNull(columnName) ? default(T) : row.Field<T>(columnName);
        }
      }
