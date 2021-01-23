        public static string ToCsv(this DataTable inDataTable, bool inIncludeHeaders = true)
        {
            var builder = new StringBuilder();
            var columnNames = inDataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            if (inIncludeHeaders)
                builder.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in inDataTable.Rows)
            {
                var fields = row.ItemArray.Select(field => field.ToString().WrapInQuotesIfContains(","));
                builder.AppendLine(string.Join(",", fields));
            }
            return builder.ToString();
        }
        public static string WrapInQuotesIfContains(this string inString, string inSearchString)
        {
            if (inString.Contains(inSearchString))
                return "\"" + inString+ "\"";
            return inString;
        }
