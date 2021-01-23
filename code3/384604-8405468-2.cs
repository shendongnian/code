    static class SqlDataRecordExtensions
    {
        static void SetNullableInt32(this SqlDataRecord rec, int index, Int32? value)
        {
            rec.SetSqlInt32(index, value.HasValue ? value.Value : SqlInt32.Null);
            //                                      ^^^^^^^^^^^^
            //                                      You can leave out the cast to (SqlInt32),
            //                                      because the conversion is implicit
        }
    }
