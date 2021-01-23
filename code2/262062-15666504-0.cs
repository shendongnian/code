    public class EFConnectionAccessor : IDisposable
    {
        private readonly SqlConnection sqlConnection;
        private readonly MyEntities entities;
    
        public EFConnectionAccessor()
        {
            entities = new MyEntities();
            
            var entityConnection = entities.Connection as EntityConnection;
            
            if (entityConnection != null)
            {
                sqlConnection = entityConnection.StoreConnection as SqlConnection;
            }
        }
    
        public SqlConnection connection
        {
            get
            {
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    
        public void Dispose()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
            entities.Dispose();
        }
    }
