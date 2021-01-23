    using System.Data.SqlClient;
    using System.Configuration;
    string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
    SqlConnection SqlConnection = new SqlConnection(connectionString);
    SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
    SqlCommand SqlCommand = new SqlCommand();
    
    SqlConnection.Open();
    SqlCommand.CommandText = "select * from table";
    SqlCommand.Connection = SqlConnection;
    SqlDataReader dr = SqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
 
