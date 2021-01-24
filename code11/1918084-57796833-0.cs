    using System;
    using System.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    public class DBContext 
    {
        public static void SetConnectionString(string connectionString)
        {
            if (ConnectionString == null)
            {
                ConnectionString = connectionString;
            }
            else
            {
                throw new Exception();
            }
        }
		// this part will help you to open the connection
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
        private static string ConnectionString { get; set; }
		
		//add the connectionString to options
		
		  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
Now, in the API project add a reference of the EFData project and in the startup.cs file set the ConnectionString
 public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var connectionString = this.Configuration.GetConnectionString("DBName");
            Namespace.DBContextContext.SetConnectionString(connectionString); //replace namespace with the namespace suitable for your solution
			
			//here goes rest of your default code
		}
This way you should be able to access the Connection in your API project.
