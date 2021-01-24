    namespace YOUR_NAMESPACE
    {
        public static class MyExtensions
        {
            public static object OrDBNull( this String value )
            {
                return String.IsNullOrEmpty(value) ? DBNull.Value : value;
            }
        }   
    }
    ...
    cmd.Parameters.AddWithValue("@surname", surname.OrDBNull());
