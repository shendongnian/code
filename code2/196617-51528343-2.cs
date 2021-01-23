    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace LaunchJobAndWaitTillDone
    {
        class Program
        {
            const string connectionString = "Data Source=YOURSERVERNAMEHERE;Initial Catalog=msdb;Integrated Security=SSPI";
            const string jobName = "YOURJOBNAMEHERE";
            static readonly TimeSpan waitFor = TimeSpan.FromSeconds(1.0);
    
            enum JobExecutionResult
            {
                Succeeded,
                FailedToStart,
                FailedAfterStart,
                Unknown
            }
    
            static void Main(string[] args)
            {
                var instance = new Program();
                JobExecutionResult jobResult = instance.RunJob(jobName);
    
                switch (jobResult)
                {
                    case JobExecutionResult.Succeeded:
                        Console.WriteLine($"SQL Server Agent job, '{jobName}', ran successfully to completion.");
                        break;
                    case JobExecutionResult.FailedToStart:
                        Console.WriteLine($"SQL Server Agent job, '{jobName}', failed to start.");
                        break;
                    case JobExecutionResult.FailedAfterStart:
                        Console.WriteLine($"SQL Server Agent job, '{jobName}', started successfully, but encountered an error.");
                        break;
                    default:
                        Console.WriteLine($"Unknown result from attempting to run SQL Server Agent job, '{jobName}'.");
                        break;
                }
    
                Console.ReadLine();
                return;
            }
    
            JobExecutionResult RunJob(string jobName)
            {
                int jobResult;
    
                using (var jobConnection = new SqlConnection(connectionString))
                {
                    SqlCommand jobCommand;
                    SqlParameter jobReturnValue;
                    SqlParameter jobParameter;
    
                    jobCommand = new SqlCommand("sp_start_job", jobConnection);
                    jobCommand.CommandType = CommandType.StoredProcedure;
    
                    jobReturnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                    jobReturnValue.Direction = ParameterDirection.ReturnValue;
                    jobCommand.Parameters.Add(jobReturnValue);
    
                    jobParameter = new SqlParameter("@job_name", SqlDbType.VarChar);
                    jobParameter.Direction = ParameterDirection.Input;
                    jobCommand.Parameters.Add(jobParameter);
                    jobParameter.Value = jobName;
    
                    jobConnection.Open();
                    try
                    {
                        jobCommand.ExecuteNonQuery();
                        jobResult = (Int32)jobCommand.Parameters["@RETURN_VALUE"].Value;
                    }
                    catch (SqlException)
                    {
                        jobResult = -1;
                    }
                }
    
                switch (jobResult)
                {
                    case 0:
                        break;
                    default:
                        return JobExecutionResult.FailedToStart;
                }
    
                while (true)
                {
                    using (var jobConnection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand jobCommand2 = new SqlCommand("sp_help_jobactivity", jobConnection2);
                        jobCommand2.CommandType = CommandType.StoredProcedure;
    
                        SqlParameter jobReturnValue2 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                        jobReturnValue2.Direction = ParameterDirection.ReturnValue;
                        jobCommand2.Parameters.Add(jobReturnValue2);
    
                        SqlParameter jobParameter2 = new SqlParameter("@job_name", SqlDbType.VarChar);
                        jobParameter2.Direction = ParameterDirection.Input;
                        jobCommand2.Parameters.Add(jobParameter2);
                        jobParameter2.Value = jobName;
    
                        jobConnection2.Open();
                        SqlDataReader rdr = jobCommand2.ExecuteReader();
                        while (rdr.Read())
                        {
                            object msg = rdr["message"];
                            object run_status = rdr["run_status"];
                            if (!DBNull.Value.Equals(msg))
                            {
                                var message = msg as string;
                                var runStatus = run_status as Int32?;
                                if (message != null && message.StartsWith("The job succeeded")
                                    && runStatus.HasValue && runStatus.Value == 1)
                                {
                                    return JobExecutionResult.Succeeded;
                                }
                                else if (message != null && message.StartsWith("The job failed"))
                                {
                                    return JobExecutionResult.FailedAfterStart;
                                }
                                else if (runStatus.HasValue && runStatus.Value == 1)
                                {
                                    return JobExecutionResult.Unknown;
                                }
                            }
                        }
                    }
    
                    System.Threading.Thread.Sleep(waitFor);
                }
            }
        }
    }
