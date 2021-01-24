    public class NoBatchingDb : Db
    {
        public NoBatchingDb() : base(disableBatching: true) { }
    }
     
