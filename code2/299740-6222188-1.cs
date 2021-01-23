    public class HGGameRepository : IGameRepository
    {
        private HGEntities _siteDB;
    
        public HGGameRepository(HGEntities entities)
        {
              _siteDB= entities
        }
    }
