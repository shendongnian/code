    public class ClientRepository<T> where T : IPassword
        {
            private readonly IMongoUOWRepositoryGeneric<T> _manager;
            readonly IMapper _mapper;
    
            public ClientRepository(IMongoUOWRepositoryGeneric<T> manager, IMapper mapper)
            {
                _manager = manager;
                _mapper = mapper;
            }
    
            public async Task<bool> AddAsync<U>(U dto) where U : IPassword
            {
                T data = _mapper.Map<T,U>(dto);
    
                data.PaswordHash = PBKDF2Hasher.HashPassword(dto.Password);
    
                await _manager.Clients.AddAsync(data);
    
                return true;
            }
        }
