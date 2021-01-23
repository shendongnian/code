    ...
    const string sqlStatement = "INSERT INTO Iterations (ProjectID, StartDate, EndDate) VALUES (@ProjectID, @StartDate, @EndDate)";
    conn.Open();
    SqlCommand cmd = new SqlCommand(sqlStatement, conn);
    cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
    cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
    cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
    
    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-GB");
    foreach (string item in sc)
    {
    
        if (item.Contains(","))
        {
            splitItems = item.Split(",".ToCharArray());
            
            cmd.Parameters["@ProjectID"].Value = splitItems[0];
            cmd.Parameters["@StartDate"].Value = Convert.ToDateTime(splitItems[1], ci);
            cmd.Parameters["@EndDate"].Value = Convert.ToDateTime(splitItems[2], ci);
    
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
    ...
