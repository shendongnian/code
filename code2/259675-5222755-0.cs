    public class DAL: IDbAccessLayer
    {
        private readonly string _connectionString;
        public DAL(string connectionString) 
        {
            _connectionString = connectionString;
        } 
   
        ... implementation of the IDbAccessLayer methods
    }
