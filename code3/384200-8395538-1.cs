    interface IPocoRepository {
        Poco GetById(int id);
    }
    class DatabasePocoRepository : IPocoRepository {
        public Poco GetById(int id) {
            // read the POCO from the database
        }
    }
    class CachePocoRepository : IPocoRepository {
        private readonly IPocoRepository pocoRepository;
        public PocoCachingRepository(IPocoRepository pocoRepository) {
            this.pocoRepositry = pocoRepository;
        }
    
        public Poco GetById(int id) {
            // read from the cache
            // if available, return it
            // if not, load using pocoRepository and cache
        }
    }
