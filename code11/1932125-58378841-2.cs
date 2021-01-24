    public class Data {
        private Func<IDbConnection> Factory { get; }
        public Data(Func<IDbConnection> factory) {
            Factory = factory;
        }
        public IList<Customer> FindAll() {
            using (IDbConnection connection = Factory.Invoke()) {
                const string sql = "SELECT Id, Name FROM Customer";
                using (IDbCommand command = connection.CreateCommand()) {                    
                    command.CommandText = sql;
                    
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader()) {
                        IList<Customer> rows = new List<Customer>();
                        while (reader.Read()) {
                            rows.Add(new Customer {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            });
                        }
                        return rows;
                    }
                }
            }
        }
    }
