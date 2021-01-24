    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            SqlConnection connection = GetSqlConnection();
            services.AddDbContext(options => options.UseSqlServer(connection));
        }
    }
