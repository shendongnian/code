    public abstract class ETLBase
    {
        private readonly string sourceConnectionString;
        private readonly string destinationConnectionString;
        protected virtual string Select { get; set; } = @"Select THIS DataStatement";
        protected virtual string CreateTemp { get; set; } = @"CREATE TABLE Statement";
        protected virtual string Merge { get; set; } = @"Merge Table statement";
        protected virtual string CleanUp { get; set; } = "DROP TABLE Statement";
        protected virtual string DestinationTable { get; set; } = "##TempTable";
        protected ETLBase(string sourceConnectionString, string destinationConnectionString)
        {
            this.sourceConnectionString = sourceConnectionString;
            this.destinationConnectionString = destinationConnectionString;
        }
        public void ExecuteJob()
        {
            using (OracleConnection sourceConnection = new OracleConnection(sourceConnectionString))
            {
                sourceConnection.Open();
                OracleCommand selectCommand = new OracleCommand(Select, sourceConnection);
                OracleDataReader reader = selectCommand.ExecuteReader();
                using (SqlConnection destinationConnection = new SqlConnection(destinationConnectionString))
                {
                    destinationConnection.Open();
                    SqlCommand createTempCommand = new SqlCommand(CreateTemp, destinationConnection);
                    createTempCommand.ExecuteNonQuery();
                    SqlCommand mergeCommand = new SqlCommand(Merge, destinationConnection);
                    SqlCommand dropCommand = new SqlCommand(CleanUp, destinationConnection);
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = DestinationTable;
                        try
                        {
                            bulkCopy.WriteToServer(reader);
                            mergeCommand.ExecuteNonQuery();
                            dropCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
            }
        }
