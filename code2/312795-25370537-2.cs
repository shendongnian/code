    public static class SQLExtension
    {
        public static SqlParameter AddWithNullable<T>(
            this SqlParameterCollection collection, 
            string parameterName, 
            Nullable<T> value) where T : struct, IComparable
        {
            return collection.AddWithValue(
                parameterName, (value.HasValue ? value.Value : (object)DBNull.Value)
            );
        }
    }
