    public partial class leDataContext
    {
        private static DecryptedConnectionString;
        static leDataContext()
        {
            // This code is guaranteed to run only once, by the framework, before any calls to the instance constructor below.
            connectionString = Cryptography.Decrypt(ConfigurationManager.ConnectionStrings["leConnString"].ToString());
        }
    
        public leDataContext()
            : base("")
        {           
            base.Connection.ConnectionString = DecryptedConnectionString;
        }
    }
