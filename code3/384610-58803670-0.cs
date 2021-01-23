    public static class ExtensionSqlDataRecord
    {
        public static void SetDateTime(this SqlDataRecord record, int ordinal, DateTime? value)
        {
            if (value != null)
            {
                record.SetDateTime(ordinal, (DateTime)value);
            }
            else
            {
                record.SetDBNull(ordinal);
            }
        }
        public static void SetInt32(this SqlDataRecord record, int ordinal, int? value)
        {
            if (value != null)
            {
                record.SetInt32(ordinal, (int)value);
            }
            else
            {
                record.SetDBNull(ordinal);
            }
        }
        public static void SetByte(this SqlDataRecord record, int ordinal, byte? value)
        {
            if (value != null)
            {
                record.SetByte(ordinal, (byte)value);
            }
            else
            {
                record.SetDBNull(ordinal);
            }
        }
        public static void SetDecimal(this SqlDataRecord record, int ordinal, decimal? value)
        {
            if (value != null)
            {
                record.SetDecimal(ordinal, (decimal)value);
            }
            else
            {
                record.SetDBNull(ordinal);
            }
        }
        public static void SetBoolean(this SqlDataRecord record, int ordinal, bool? value)
        {
            if (value != null)
            {
                record.SetBoolean(ordinal, (bool)value);
            }
            else
            {
                record.SetDBNull(ordinal);
            }
        }
    }
