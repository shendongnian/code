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
    
            static void Main(string[] args)
            {
                SqlConnection jobConnection;
                SqlCommand jobCommand;
                SqlParameter jobReturnValue;
                SqlParameter jobParameter;
                int jobResult;
    
                jobConnection = new SqlConnection(connectionString);
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
                jobCommand.ExecuteNonQuery();
                jobResult = (Int32)jobCommand.Parameters["@RETURN_VALUE"].Value;
                jobConnection.Close();
    
                switch (jobResult)
                {
                    case 0:
                        Console.WriteLine($"SQL Server Agent job, '{jobName}', started successfully.");
                        break;
                    default:
                        Console.WriteLine($"SQL Server Agent job, '{jobName}', failed to start.");
                        break;
                }
    
                while (!Console.KeyAvailable)
                {
                    SqlCommand jobCommand2 = new SqlCommand("sp_help_jobactivity", jobConnection);
                    jobCommand2.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter jobReturnValue2 = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                    jobReturnValue2.Direction = ParameterDirection.ReturnValue;
                    jobCommand2.Parameters.Add(jobReturnValue2);
    
                    SqlParameter jobParameter2 = new SqlParameter("@job_name", SqlDbType.VarChar);
                    jobParameter2.Direction = ParameterDirection.Input;
                    jobCommand2.Parameters.Add(jobParameter2);
                    jobParameter2.Value = jobName;
    
                    jobConnection.Open();
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
                                Console.WriteLine("The job finished successfully.");
                                Console.ReadLine();
                                jobConnection.Close();
                                return;
                            }
                        }
                    }
                    jobConnection.Close();
    
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
