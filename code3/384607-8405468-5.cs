    static class SqlDataRecordExtensions
    {
        static void SetNullableInt32(this SqlDataRecord rec, int index, Int32? value)
        {
            if (value.HasValue)
                rec.SetInt32(index, value.GetValueOrDefault());
            else
                rec.SetDBNull(index);
        }
    }
