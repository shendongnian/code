    public void GetJobsAndStatus()
            {
                string sqlJobQuery = "select j.job_id, j.name, j.enabled, jh.run_status," +
                " js.last_outcome_message, jh.run_date, jh.step_name, jh.run_time" +
                " from sysjobs j left join sysjobhistory jh on (j.job_id = jh.job_id)" +
                " left join sysjobservers js on (j.job_id = js.job_id)" +
                " where jh.run_date = (select Max(run_date) from sysjobhistory)" +
                " and jh.run_time = (select Max(run_time) from sysjobhistory)";
                // create SQL connection and set up SQL Command for query
                using (SqlConnection _con = new SqlConnection("server=10.15.13.70;database=msdb;user id=sa;pwd="))
                using (SqlCommand _cmd = new SqlCommand(sqlJobQuery, _con))
                {
               
                    try
                   {
                   // open connection
                   _con.Open();
                   SqlConnection.ClearPool(_con);
                   // create SQL Data Reader and grab data
                   using (SqlDataReader rdr = _cmd.ExecuteReader())
                   {
                       // as long as we get information from the reader
                       while (rdr.Read())
                       {
                           Guid jobID = rdr.GetGuid(0);             // read Job_id
                           string jobName = rdr.GetString(1);       // read Job name
                           byte jobEnabled = rdr.GetByte(2);        // read Job enabled flag
                           int jobStatus = rdr.GetInt32(3);         // read last_run_outcome from sysjobserver
                           string jobMessage = rdr.GetString(4);    // read Message from sysjobserver
                           int jobRunDate = rdr.GetInt32(5);        // read run_date from sysjobhistory
                           string jobStepName = rdr.GetString(6);   // read StepName from sysjobhistory
                           int jobRunTime = rdr.GetInt32(7);        // read run_time from sysjobhistory
                          
                            String[] lviData = new String[] // ตัวแปรอะเรย์ชื่อ lviData 
                        { 
                            jobID.ToString(),
                            jobName.ToString(),
                            jobStepName.ToString(),
                            jobMessage.ToString(), 
                            jobStatus.ToString(),
                            jobRunDate.ToString(),
                            jobRunTime.ToString(),
                            //jobEnabled.ToString(), 
              
                        };
                            newData = lviData;
                            DisplayList();  // for display data on datagridview
                       
                       }
                       rdr.Close();
                   }
               }
