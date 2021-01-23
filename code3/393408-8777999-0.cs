    using System;
    using System.Net.Sockets;
    using BookSleeve;
    
    namespace Redis
    {
        public sealed class RedisConnectionGateway
        {
            private const string RedisConnectionFailed = "Redis connection failed.";
            private static RedisConnection _connection;
            private static RedisConnectionGateway _instance;
            private static object syncLock = new object();
            private static object syncConnectionLock = new object();
    
            public static RedisConnectionGateway Current()
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RedisConnectionGateway();
                        }
                    }
                }
    
                return _instance;
            }
    
            private RedisConnectionGateway()
            {
                _connection = getNewConnection();
            }
    
            private static RedisConnection getNewConnection()
            {
                return new RedisConnection("127.0.0.1" /* change with config value of course */, syncTimeout: 5000, ioTimeout: 5000);
            }
    
            public RedisConnection GetConnection()
            {
                lock (syncConnectionLock)
                {
                    if (_connection == null)
                        _connection = getNewConnection();
    
                    if (_connection.State == RedisConnectionBase.ConnectionState.Opening)
                        return _connection;
    
                    if (_connection.State == RedisConnectionBase.ConnectionState.Closing || _connection.State == RedisConnectionBase.ConnectionState.Closed)
                    {
                        try
                        {
                            _connection = getNewConnection();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(RedisConnectionFailed, ex);
                        }
                    }
    
                    if (_connection.State == RedisConnectionBase.ConnectionState.Shiny)
                    {
                        try
                        {
                            var openAsync = _connection.Open();
                            _connection.Wait(openAsync);
                        }
                        catch (SocketException ex)
                        {
                            throw new Exception(RedisConnectionFailed, ex);
                        }
                    }
    
                    return _connection;
                }
            }
        }
    }
