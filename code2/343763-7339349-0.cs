    public DataTable GetVisits(System.DateTime startDate, System.DateTime endData)
    {
    	var connString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
    	var tblVisits = new DataTable("Visits");
    	using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connString)) {
    		var cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(UPPER(SUBSTRING(visit_Status, 1, 1)), SUBSTRING(visit_Status FROM 2))  as Status, COUNT('x') AS Visits FROM(visits)  WHERE visit_Date BETWEEN @startDate AND @endData GROUP BY visit_Status", conn);
    		var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
    		var param = new MySql.Data.MySqlClient.MySqlParameter("@startDate", MySql.Data.MySqlClient.MySqlDbType.Date);
    		param.DbType = DbType.Int32;
    		param.Direction = ParameterDirection.Input;
    		param.Value = startDate;
    		cmd.Parameters.Add(param);
    		param = new MySql.Data.MySqlClient.MySqlParameter("@endDate", DbType.Date);
    		param.Direction = ParameterDirection.Input;
    		param.Value = endData;
    		cmd.Parameters.Add(param);
    		conn.Open();
    		da.Fill(tblVisits);
    	}
    
    	return tblVisits;
    }
