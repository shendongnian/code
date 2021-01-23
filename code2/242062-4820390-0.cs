    public class Connection: IConnection
    {
        public string ConnectionString{ get; set; }
    
        public Connection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    
        public Connection():this(ConfigurtionManager.ConnectionStrings["connection"].ConnectionString)
        {
            //Broke DI in the interest of usability.
        }
    }
