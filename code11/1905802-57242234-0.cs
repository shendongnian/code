    public static class DataRowExtensions
    {
        public static object Compute(this DataRow dataRow, string expression)
        {
            var clonedDT = dataRow.Table.Clone();
            clonedDT.ImportRow(dataRow);
            var clonedRow = clonedDT.Rows[0];
            var dataColumn = clonedDT.Columns.Add(null, typeof(object), expression);
            return clonedRow[dataColumn];
        }
        public static T Compute<T>(this DataRow dataRow, string expression)
        {
            var clonedDT = dataRow.Table.Clone();
            clonedDT.ImportRow(dataRow);
            var clonedRow = clonedDT.Rows[0];
            var dataColumn = clonedDT.Columns.Add(null, typeof(T), expression);
            return clonedRow.Field<T>(dataColumn);
        }
        public static T? ComputeNullable<T>(this DataRow dataRow, string expression)
            where T : struct
        {
            var clonedDT = dataRow.Table.Clone();
            clonedDT.ImportRow(dataRow);
            var clonedRow = clonedDT.Rows[0];
            var dataColumn = clonedDT.Columns.Add(null, typeof(T), expression);
            return clonedRow.Field<T?>(dataColumn);
        }
    }
