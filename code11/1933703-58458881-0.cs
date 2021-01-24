     public static bool IsNullEquivalent( this object value)
            {
                return value == null
                       || value is DBNull
                       || string.IsNullOrWhiteSpace(value.ToString());
            }
            public static bool IsEmptyDataRow(this  DataRow row)
            {
                return row == null || row.ItemArray.All(i => i.IsNullEquivalent());
            }
            public static bool IsEmptyDatatable (this DataTable dt)
            {
                return dt == null || dt.Rows.Cast<DataRow>().All(i => i.IsEmptyDataRow());
            }
