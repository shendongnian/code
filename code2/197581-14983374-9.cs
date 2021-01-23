    internal class EntityConnectionManager : IDisposable
    {
        private DbConnection _connection;
        private EntityConnection _entityConnection;
    
        private volatile bool _disposed;
    
        public EntityConnectionManager()
        {
            var workspace = new MetadataWorkspace(Setting.MetadataWorkspacePaths.Split('|'), new[] { Assembly.ReflectionOnlyLoad(Setting.MetadataAssemblyNameToConsider) });
    
            _connection = new SqlConnection(Setting.ConnectionString);
            _entityConnection = new EntityConnection(workspace, _connection);
            _disposed = false;
        }
    
        public EntityConnection Connection
        {
            get { return _entityConnection; }
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                    if (_entityConnection != null)
                    {
                        _entityConnection.Dispose();
                        _entityConnection = null;
                    }
                }
            }
            _disposed = true;
        }
    }
