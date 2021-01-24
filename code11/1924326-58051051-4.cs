    public class MyDataProvider : IDataProvider {
        static string LastErrorMsg = string.Empty;
        private readonly string connectionString;
        private readonly IDbConnectionFactory connectionFactory;
        public MyDataProvider(ConnectionStrings connections, IDbConnectionFactory connectionFactory) {
            this.connectionString = connections.DefaultConnection;
            this.connectionFactory = connectionFactory;
        }
        public List<DropDownOption> CalcSelectDDSizeAndTilesPerBoxAll() {
            var options = new List<DropDownOption>();
            try {
                using (IDbConnection connection = connectionFactory.Create(connectionString)) {
                    using (IDbCommand command = connection.CreateCommand()) {
                        command.CommandText = "CalcSelectDDSizeAndTilesPerBoxAll";
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 30;
                        connection.Open();
                        using (IDataReader r = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (r.Read()) {
                                DropDownOption option = new DropDownOption {
                                    value = r["SizeAndNumInBox"].ToString(),
                                    text = r["Descr"].ToString()
                                };
                                options.Add(option);
                            }
                        }
                        LastErrorMsg = string.Empty;
                    }
                }
            } catch (Exception ex) {
                LastErrorMsg = ex.Message;
                //consider logging error
                options = new List<DropDownOption>();
            }
            return options;
        }
    }
