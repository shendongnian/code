    public class ACRepository : BaseRepository<ACEntity>, IACRepository
    {
        private readonly IDbConnection _dbConnection;
        public ACRepository(IDbConnection _dbconn) : base(_dbconn)
        {
            _dbConnection = _dbconn;
        }
    }
 
