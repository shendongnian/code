     var conn = Database.DefaultConnectionFactory.CreateConnection(GetConnectionString(context));
            try
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SearchJobs";
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameter(cmd, "serviceProviderId", filter.ServiceProviderId);
                    AddParameter(cmd, "service", filter.Service);
                    AddParameter(cmd, "statuses", string.Join(",", filter.Statuses));
                    AddParameter(cmd, "deadlineFrom", filter.DeadlineFrom);
                    AddParameter(cmd, "deadlineTo", filter.DeadlineTo);
                    
                    using (var rdr = cmd.ExecuteReader())
                    {
                        //I just need a read-only list for viewing, so I won’t worry about change tracking
                        //the objects need to be read out of the DbReader before it is closed 
                        jobs = context.ObjectContext.Translate<Job>(rdr, GetEntitySetName<Job>(context), MergeOption.AppendOnly).ToList();
                        rdr.NextResult();
                        documentRequests = context.ObjectContext.Translate<DocumentRequest>(rdr, GetEntitySetName<DocumentRequest>(context), MergeOption.AppendOnly).ToList();
                        rdr.NextResult();
                        serviceorders = context.ObjectContext.Translate<ServiceOrder>(rdr, GetEntitySetName<ServiceOrder>(context), MergeOption.AppendOnly).ToList();
                    }
                    fetch.Stop();
                }
            }
            finally
            {
                conn.Close();
            }
