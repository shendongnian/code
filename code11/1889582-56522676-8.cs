     public class ClientRepository<T> 
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
                dto.PaswordHash = PBKDF2Hasher.HashPassword(dto.Password);
                T data = _mapper.Map<T,U>(dto);               
                await _manager.Clients.AddAsync(data);
                return true;
            }
        }
