    public class XRepository : BaseRepository<X>, IXRepository { }
    public class YRepository : BaseRepository<Y>, IYRepository { }
    
    public class ZRepository : BaseRepository<Z>, IZRepository
    {
        private readonly IXRepository _xRepository;
        private readonly IYRepository _yRepository;
    
        public ZRepository(IXRepository xRepository, IYRepository yRepository)
        {
            _xRepository = xRepository;
            _yRepository = yRepository;
        }
    }
