    public class MongoVoyageRepository : IVoyageRepository
    {
        private readonly MongoRead context
        {
          get { return MongoRead.Instance; }
        };
    
        public MongoVoyageRepository()
        {
        }
    
        public void Store(Domain.Model.Voyages.Voyage voyage)
        {
                MongoCollection<Voyage> mongoVoyages = 
                      context.Database.GetCollection<Voyage>("Voyages");
                //store logic...
        }
    
    }
