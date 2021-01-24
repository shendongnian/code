    public class DefaultSqlDatabase<T> : ISqlDatabase<T> where T : class, ISQLGeneralDB, new() {
        private IDbConnectionFactory factory;
        public DefaultSqlDatabase(IDbConnectionFactory factory) {
            this.factory = factory;
        }
        public List<T> ReadTable(string sqlcommand) {
            var selectedlist = new List<T>();
            using (IDbConnection connection = factory.CreateConnection()) {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand()) {
                    try {
                        command.CommandText = sqlcommand;
                        using (var dataReader = command.ExecuteReader()) {
                            while (dataReader.Read()) {
                                object[] objectarray = new object[dataReader.FieldCount];
                                dataReader.GetValues(objectarray);
                                ISQLGeneralDB objectfetcher = new T();
                                selectedlist.Add((T)objectfetcher.FetchRow(objectarray));
                            }
                            return selectedlist;
                        }
                    } catch (IndexOutOfRangeException) {
                        throw;
                    } catch (Exception ex) {
                        throw;
                    }
                }
            }
        }
    }
    
