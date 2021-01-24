    //most datetime comparisons want an *exclusive* upper bound, but the BETWEEN operator bounds are inclusive on both ends
    var sql = "SELECT daytime AS DATE, COLUMN_2 AS SHIFT, COLUMN_3 AS 'PART NO',COLUMN_4 AS 'PART NAME',BSNO AS 'BASKET NUMBER',Spare1 AS MATERIAL, CAS6 AS 'CASCADE RINSE 6 TIME (sec)',DRY AS 'DRYER TIME (sec)',TEMP1 AS 'DRYER TEMP (°c)' FROM Table_2 WHERE daytime >= @daytimeStart AND daytime < @daytimeEnd ;";
    var dt = new DataTable();
    //don't try to re-use your connection object. 
    // .Net connection pooling means you should create a new connection for most queries
    using (var con = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, con))
    using (var da = new SqlDataAdapter(cmd))
    {  //These using blocks guarantee the connection is closed, even if an exception is thrown
        //This is the correct way to include user data with your sql statement
        // **NEVER** use string concatenation to substitute values into SQL strings
        cmd.Parameters.Add("@daytimeStart", SqlDbType.DateTime).Value =  dateTimePicker1.Value;
        cmd.Parameters.Add("@daytimeEnd", SqlDbType.DateTime).Value =  dateTimePicker2.Value;
        //the Fill() method opens and closes the connection as needed
        da.Fill(dt);
    }
    metroGrid1.DataSource = dt;
