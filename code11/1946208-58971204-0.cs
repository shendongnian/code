    public Int64 PostBulkMessage(List<Bulk> bData)
            {
    
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Mobile", typeof(string));
                dt.Columns.Add("MessageContent", typeof(string));
               
                for (int i = 0; i < bData.Count(); i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = bData[i].Id;
                    dr[1] = bData[i].Mobile;
                    dr[2] = bData[i].MessageContent;
                    
                    dt.Rows.Add(dr);
                }
                                      
                if (dt.Rows.Count > 0)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnEntities"].ConnectionString;
                    if (connectionString.ToLower().StartsWith("metadata="))
                    {
                        System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(connectionString);
                        connectionString = efBuilder.ProviderConnectionString;
                    }
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            sqlBulkCopy.DestinationTableName = "dbo.BulkMsg";
                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                    }
                }
                return 0;
            }
     public class Bulk
            {
    
                public string Id { get; set; }
                public string Mobile { get; set; }
                public string MessageContent { get; set; }
            }
