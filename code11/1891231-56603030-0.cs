    public class Monkey {
        
        private List<Banana> bananas;
        private IDatabase database;
    
        public Monkey(IDatabase database)
        {
            this.database = database;
            this.GetBananasFromDatabase()
        }
    
        public List<Banana> PeeledBananas {
            get {
                List<Banana> peeledBananas = new List<Banana>();
                foreach(Banana banana in this.bananas)
                {
                    if(banana.IsPeeled)
                    {
                        peeledBananas.Add(banana);
                    }
                }
                return peeledBananas;
            }
        }
    
        private GetInfoFromDatabase()
        {
            this.bananas = this.database.GetBananas();
        }
    }
