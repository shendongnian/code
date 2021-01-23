    public class AppConfigConnectionFactory : IConnectionFactory
    {
       public IDbConnection Create() 
       { 
            return new SqlConnection(ConfigurationManager
                 .ConnectionStrings["ApplicationServices"].ConnectionString);
       }
    }
    c.RegisterType<IConnectionFactory, AppConfigConnectionFactory>();
    c.RegisterType<IDepartmentRepository, DepartmentRepository>();
