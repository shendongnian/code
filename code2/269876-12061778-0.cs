    public static class SqlExtensions
        {
            public static void AddNullableParameterWithValue(this SqlCeCommand cmd, string name, object value)
            {
                if (null != value)
                    cmd.Parameters.AddWithValue(name, value);
                else
                    cmd.Parameters.AddWithValue(name, DBNull.Value);
            }
        }
