    public void CreateTable(Type linqTableClass)
    {
    	using (var tempDc = new DmsDataContext())
    	{
    		var metaTable = tempDc.Mapping.GetTable(linqTableClass);
    		var typeName = "System.Data.Linq.SqlClient.SqlBuilder";
    		var type = typeof(DataContext).Assembly.GetType(typeName);
    		var bf = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
    		var sql = type.InvokeMember("GetCreateTableCommand", bf, null, null, new[] { metaTable });
    		var sqlAsString = sql.ToString();
    		tempDc.ExecuteCommand(sqlAsString);
    	}
    }
     
