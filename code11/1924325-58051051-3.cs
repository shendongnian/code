    public class ConnectionStrings {
        public string DefaultConnection { get; set; }
    }
    public interface IDbConnectionFactory {
        IDbConnection Create(string connectionString);
    }
    public class SqlConnectionFactory : IDbConnectionFactory {
        public IDbConnection Create(string connectionString) {
            return new SqlConnection(connectionString);
        }
    }
    public interface IDataProvider {
        List<DropDownOption> CalcSelectDDSizeAndTilesPerBoxAll();
    }
