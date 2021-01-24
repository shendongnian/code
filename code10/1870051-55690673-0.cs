    public class FooRepository
    {
        private readonly IConfiguration _configuration;
        public FooRepository(IConfiguration configuration)
        {
            _configuration = configuration
        }
        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("myConnectionString"));
        public Foo GetById(int id)
        {
            using (var connection = Connection)
            {
                return connection.QueryFirstOrDefault<Foo>("select * from ...", new {id});
            }
        }
    }
