    public class JobInfo
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public byte Enabled { get; set; }
        public int Status { get; set; }
    }
    public List<JobInfo> GetJobsAndStatus()
    {
       List<JobInfo> _jobs = new List<JobInfo>();
       
       string sqlJobQuery = "select j.job_id, j.name, j.enabled, jh.run_state " +
                            "from sysjobs j inner join sysjobhistory jh on j.job_id = jh.job_id";
       // create SQL connection and set up SQL Command for query
       using(SqlConnection _con = new SqlConnection("server=10.17.13.70;database=msdb;user id=sa;pwd=XXXXXXX"))
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
                   byte jobEnabled = rdr.GetByte(2);   // read Job enabled flag
                   int jobStatus = rdr.GetInt32(3);    // read run_state from jobhistory
                   _jobs.Add(new JobInfo { Name = jobName, 
                                           ID = jobID, 
                                           Enabled = jobEnabled,
                                           Status = jobStatus });
	    }
	    rdr.Close();
	}
	// close connection again
	_con.Close();     
	
	return _jobs;
    }
