    public class Db : DbContext
    {
        bool disableBatching = false;
     
        public Db() : base()
        {
    
        }
        public Db(bool disableBatching)
        {
            this.disableBatching = true;
        }
