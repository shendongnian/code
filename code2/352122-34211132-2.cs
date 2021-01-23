    public static class DatabaseExtensions
    {
        public static void AddTableTypeParameter<T>(this Database database, DbCommand command, string name, string sqlType, IEnumerable<T> values)
        {
            var table = new DataTable();
            PropertyInfo[] members = values.First().GetType().GetProperties();
            foreach (var member in members)
            {
                table.Columns.Add(member.Name, member.PropertyType);
            }
            foreach (var value in values)
            {
                var row = table.NewRow();
                row.ItemArray = members.Select(m => m.GetValue(value)).ToArray();
                table.Rows.Add(row); 
            }
            var parameter = new SqlParameter(name, SqlDbType.Structured)
            {
                TypeName = sqlType,
                SqlValue = table
            };
            command.Parameters.Add(parameter);
        }
    }
