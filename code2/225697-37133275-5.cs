    public abstract class BaseDataAccess : IDataAccess
    {
        /// <summary> Enterprise library data block Database object. </summary>
        public Database Database;
        
        
        public Customer GetDetails(string lastName)
        {
            // use the database object to call the stored procedure to retrieve the customer details
        }
    }
