        private string GetConnectionStringWithWorkStationId(string connectionString, string connectionPoolToken)
        {
            if (string.IsNullOrEmpty(machineName)) machineName = Environment.MachineName;
            SqlConnectionStringBuilder cnbdlr;
            try
            {
                cnbdlr = new SqlConnectionStringBuilder(connectionString);
            }
            catch
            {
                throw new ArgumentException("connection string was an invalid format");
            }
            cnbdlr.WorkstationID = machineName + connectionPoolToken;
            return cnbdlr.ConnectionString;
        }
