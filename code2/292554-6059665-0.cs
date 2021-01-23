    public class ConnectionFactory : IConnectionFactory
    {
       public IDbConnection Create() 
       { 
            return new SqlConnection(ConfigurationManager
                 .ConnectionStrings["ApplicationServices"].ConnectionString);
       }
    }
    c.RegisterType<IConnectionFactory, ConnectionFactory>();
    c.RegisterType<IDepartmentRepository, DepartmentRepository>();
