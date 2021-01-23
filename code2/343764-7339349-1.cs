    public DataTable GetVisits(System.DateTime startDate, System.DateTime endData)
    {
        const string SQL = "SELECT CONCAT(UPPER(SUBSTRING(visit_Status, 1, 1)), SUBSTRING(visit_Status FROM 2))  as Status, COUNT('x') AS Visits FROM(visits)  WHERE visit_Date BETWEEN @startDate AND @endData GROUP BY visit_Status";
    	const string CONNSTR = "Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
    	var tblVisits = new DataTable("Visits");
    	using (var conn = new MySql.Data.MySqlClient.MySqlConnection(CONNSTR)) {
    		var cmd = new MySql.Data.MySqlClient.MySqlCommand(SQL, conn);
    		var da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
    		var param = new MySql.Data.MySqlClient.MySqlParameter("@startDate", MySql.Data.MySqlClient.MySqlDbType.Date);
    		param.Direction = ParameterDirection.Input;
    		param.Value = startDate;
    		cmd.Parameters.Add(param);
    		param = new MySql.Data.MySqlClient.MySqlParameter("@endDate", MySql.Data.MySqlClient.MySqlDbType.Date);
    		param.Direction = ParameterDirection.Input;
    		param.Value = endData;
    		cmd.Parameters.Add(param);
    		conn.Open();
    		da.Fill(tblVisits);
    	}
    
    	return tblVisits;
    }
