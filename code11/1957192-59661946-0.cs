    public async Task<TEntity> Handle<TEntity>(TEntity sportEvent)
            where TEntity : ISportEvent
    {
            var sportsRepository = new SportsRepository()
        
            ... some unimportant business logic
        
            //save the sport
            if (sport.SportID > 0) 
            {
                _sportRepository.Update(sport);
            }
            else
            {
                _sportRepository.Insert(sport);
            }
            _sportRepository.SaveDbChanges();
        
    }
    public class SportsRepository
    {
        private DbContext _dbContext;
        public SportsRepository()
        {
            _dbContext = new DbContext();
        }
    }
