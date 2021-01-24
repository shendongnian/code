    namespace YOUR_NAMESPACE
    {
        public static class MyExtensions
        {
            public static void AddString( this SqlParameterCollection collection, string parameterName, string value )
            {
                collection.AddWithValue(parameterName, String.IsNullOrEmpty(value) ? DBNull.Value : value);
            }
        }   
    }
    ...
    cmd.Parameters.AddString("@surname", surname);
