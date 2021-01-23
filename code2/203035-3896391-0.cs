    // define the query to run
    string sqlJobQuery = "select j.job_id, j.name, j.enabled, jh.run_status " +
                         "from sysjobs j inner join sysjobhistory jh on j.job_id = jh.jobid"
    // create SQL connection and set up SQL Command for query
    using(SqlConnection _con = new SqlConnection("server=10.17.13.70;database=msdb;user id=sa;pwd=XXXXXX")
    using(SqlCommand _cmd = new SqlCommand(sqlJobQuery, _con))
    {
        // open connection
        _con.Open();
        // create SQL Data Reader and grab data
        using(SqlDataReader rdr = _cmd.ExecuteReader())
        {
            // as long as we get information from the reader
            while(rdr.Read())
            {
                Guid jobID = rdr.GetGuid(0);        // read Job_id
                string jobName = rdr.GetString(1);  // read Job name
                int jobEnabled = rdr.GetInt(2);     // read Job enabled flag
                int jobRunStatus = rdr.GetInt(3);   // read job run status
                // do something with your data, e.g. store it into a list or something
            }
            rdr.Close();
        }
    
        // close connection again
        _con.Close();     
    }
    
