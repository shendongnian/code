    public interface IDbConnectionFactory {
        IDbConnection CreateConnection();
    }
    public class SqlConnectionFactory : IDbConnectionFactory {
        public IDbConnection CreateConnection() {
            return new SqlConnection(XmlWebConfigReader.GetValueFromWebConfig("connectionstring"));
        }
    }
