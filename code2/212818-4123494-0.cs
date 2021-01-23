    public static class SqlCommandExtensions
    {
        public static void AddNullableInParameter<T>(this SqlCommand command, string columnName, Nullable<T> value) where T : struct
        {
            if (value.HasValue)
            {
                command.Parameters.AddWithValue(columnName, value.Value);
            }
        }
    }
