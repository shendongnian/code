    public class GlobalAppData
        {
            private IDataRepository[] _availableRepositories;
            private IDataRepository_lastUsedRepository;
    
            /// <summary>
            /// ctor
            /// </summary>
            public GlobalAppData()
            {
                _availableRepositories = new IDataRepository[0];
            }
    
            public void TryRegisterRepositories(IEnumerable<IDataRepository> repositories)
            {
                if (_availableRepositories.Length > 0)
                {
                    return;
                }
    
                _availableRepositories = repositories.ToArray();
    
                _lastUsedRepository = null;
            }
    
            public IDataRepository GetNextRepository()
            {
                if (_lastUsedRepository == null)
                {
                    _lastUsedRepository = _availableRepositories[0];
                    return _lastUsedRepository;
                }
    
                var lastUsedIndex = _availableRepositories.IndexOf(_lastUsedRepository);
                if (lastUsedIndex < _availableRepositories.Length - 1)
                {
                    lastUsedIndex++;
                }
                else
                {
                    lastUsedIndex = 0;
                }
    
                _lastUsedRepository = _availableRepositories[lastUsedIndex];
                return _lastUsedRepository;
            }
        }
