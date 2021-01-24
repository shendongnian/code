    public partial class RedContext
     {
        // Add a constructor to allow the connection string name to be changed
     public RedContext(string connectionStringNameInConfig)
            : base("name=" + connectionStringNameInConfig)
        {
        }
    }
