private List<TEntity> GetTable(string where = null)
{
    var query = $"select * from {GetTableName()} {where}";
    var dataTable = new DataTable();
    using(var sqlConnection = new SqlConnection(connectionString))
    {
        SqlDataAdapter sqlDA = new SqlDataAdapter(query, sqlConnection);
        sqlDA.Fill(dataTable);
    }
    var entityList = new List<TEntity>();
    foreach (DataRow row in dataTable.Rows)
    {
        var entity = new TEntity();
        foreach (DataColumn column in dataTable.Columns)
        {
            var value = row[column.ColumnName];
            typeof(TEntity).GetProperty(column.ColumnName).SetValue(entity, value);
        }
        entityList.Add(entity);
    }
    return entityList;
 }
