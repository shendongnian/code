    string insertFields = "";
    string insertValues = "";
        	foreach (DataColumn col in dt.Columns)
        	{
        		insertFields += col.ColumnName + ",";
        		insertValues += "@" + col.ColumnName + ",";
        	}
    //chop off ending comma here with substring.
    
    string sql = "INSERT into T " + insertFields + " VALUES(" + insertValues + ")";
        foreach(DataRow dr in dt.Rows)
        {
        	List<SqlParameter> sqlParams = new List<SqlParameter>;
        	foreach (DataColumn col in dt.Columns)
        	{
        		sqlParams.Add(new SqlParameter(col.ColumnName, dr[col.ColumnName]));
        	}
        	//Execute cmd with sqlparams. May need to set property as sqlParams.ToArray()
        }
