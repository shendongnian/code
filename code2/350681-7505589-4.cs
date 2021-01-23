    public class DataHandler
    {
        //singleton instance
        static DataHandler _instance = new DataHandler ();
    
        public DataHandler Instance
        {
              get { return _instance; }
        }
    };
