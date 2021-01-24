        public class MyApp
        {
           private readonly IDataProvider _dbProvider;
           private readonly IHelper _h;
           public MyApp(IDataProvider dbProvider)
           {
               _dbProvider = dbProvider;
               _h = new Helper(_dbProvider);
           }
        
           public void Process()
           {
               string query = "something";
               // This method will be called in the Process method several times
               var data = _h.GetData(query);
           }
        }
    
        public interface IDataProvider 
        {
           IDbConnection CreateConnection(string connectionString);
           DataTable FillDatatableFromAdapter(IDbCommand command);
        }
    
        public class DataProvider  : IDataProvider 
        {
             public IDbConnection CreateConnection(string connectionString)
             {
                 return new SqlConnection(connectionString);
             }
        
             public DataTable FillDatatableFromAdapter(IDbCommand command)
             {
                  DataSet dataSet = new DataSet();
                  SqlCommand sqlCommand = command as SqlCommand;
                  using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                  {
                      sqlDataAdapter.Fill(dataSet);
                  }
        
                  if (dataSet.Tables.Count == 0)
                      return null;
        
                  return dataSet.Tables[0];
             }
        }
    
    public interface IHelper
    {
         public DataTable GetData(string query);
    }
    
    public class Helper
    {
       private readonly IDataProvider _dbProvider;
       public Helper(IDataProvider dbProvider)
       {
           _dbProvider = dbProvider;
       }
    
       public DataTable GetData(string query)
       { 
           DataTable table = new DataTable();
           using (IDbConnection connection = 
           _databaseProvider.CreateConnection(_connectionString))
           {
               connection.Open();
               using (IDbCommand command = connection.CreateCommand())
               {
                   command.CommandText = query;
                   command.Connection = connection;
                   table = _dbProvider.FillDatatableFromAdapter(command);
               }
           }
           return table;
        }   
    }
    
    
