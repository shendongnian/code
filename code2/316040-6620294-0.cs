    public class OdbcQuery
    {
        OdbcCommand Command { get; set; }
        public OdbcQuery(OdbcConnection connection, string cmdText)
        {
            Command = new OdbcCommand(cmdText, connection); 
        }
        public List<T> Transform<T>(Func<OdbcDataReader, T> transformFunction)
        {
            Command.Connection.Open();
            OdbcDataReader reader = Command.ExecuteReader(CommandBehavior.Default);
            List<T> tList = new List<T>();
            while (reader.Read())
            {
                tList.Add(transformFunction(reader));
            }
            Command.Connection.Close();
            return tList; 
        }
    }
