    public DL
    {
        //Assume this is disposed properly for simplicity...
        // Maybe a winforms app with fewer longer cycles, rather than a web app with lots of threads or AppDomains
        private static SqlConnection connection = new SqlConnection("...");
        public static IEnumerable<T> GetAll<T>() 
        {
            connection.Open();
            //...
            connection.Close();
        }
    }
