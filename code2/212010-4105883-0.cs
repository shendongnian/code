    public virtual Column[] GetColumns(string table)
    {
    	List<Column> columns = new List<Column>();
    	using (
    		IDataReader reader =
    			ExecuteQuery(
    				String.Format("select COLUMN_NAME, IS_NULLABLE from information_schema.columns where table_name = '{0}'", table)))
    	{
    		while (reader.Read())
    		{
    			Column column = new Column(reader.GetString(0), DbType.String);
    			string nullableStr = reader.GetString(1);
    			bool isNullable = nullableStr == "YES";
    			column.ColumnProperty |= isNullable ? ColumnProperty.Null : ColumnProperty.NotNull;
    
    			columns.Add(column);
    		}
    	}
    
    	return columns.ToArray();
    }
