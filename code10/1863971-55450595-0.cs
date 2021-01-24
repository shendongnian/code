    private static DataTable TransformData(IEnumerable<User> listUsers)
    {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("Position"));
        Dictionary<string, DataRow> positions = new Dictionary<string, DataRow>();
        foreach (var user in listUsers)
        {
            DataColumn column = dataTable.Columns.OfType<DataColumn>().FirstOrDefault(c => c.ColumnName == user.ReadTime);
            if (column == null)
            {
                column = new DataColumn(user.ReadTime);
                dataTable.Columns.Add(column);
            }
            DataRow row;
            if (!positions.TryGetValue(user.Position, out row))
            {
                row = dataTable.NewRow();
                dataTable.Rows.Add(row);
                row[0] = user.Position;
                positions.Add(user.Position, row);
            }
            object o = row[column];
            int posCou = o == DBNull.Value ? 0 : Convert.ToInt32(o);
            row[column] = posCou + user.PosCou;
        }
        return dataTable;
    }
