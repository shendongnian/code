    internal class SftpclientTest
    {
        private readonly ObjectPool<SftpClient> _objectPool;
    
    
        public SftpclientTest(Credentials credentials)
        {
            _objectPool = new ObjectPool<SftpClient>(() =>
            {
                var client = new SftpClient(credentials.host, credentials.username, credentials.password);
                client.Connect();
    
                return client;
            });
        }
    
    
        public void GetDirectoryList()
        {
            var client = _objectPool.GetObject();
    
            try
            {
                // client.ListDirectory() ..
            }
            finally
            {
                if (client.IsConnected)
                {
                    _objectPool.PutObject(client);
                }
            }
        }
    
    
        public async Task ProcessRemoteFilesAsync()
        {
            var filePaths = new List<string>();
    
            // initializing filePaths ..
    
            var tasks = filePaths
                .Select(f => ParseRemoteFileAsync(f))
                .ToArray();
    
            var results = await Task.WhenAll(tasks).ConfigureAwait(false);
    
            // traverse through results..
        }
    
        public Task<FileContent> ParseRemoteFileAsync(string filePath)
        {
            var client = _objectPool.GetObject();
    
            try
            {
                using (var remoteFileStream = client.OpenRead(filePath))
                {
                    using (var reader = new StreamReader(remoteFileStream))
                    {
                        using (var csv = new CsvReader(reader))
                        {
                            // ..
                        }
                    }
    
                    return Task.FromResult(new FileContent());
                }
            }
            finally
            {
                if (client.IsConnected)
                {
                    _objectPool.PutObject(client);
                }
            }
        }
    }
