            if (connectionString.Contains("http://"))
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                string newConString = connectionString.Replace("http://", "");
                return new Channel(newConString, ChannelCredentials.Insecure);
            }
            else
            {
                string newConString = connectionString.Replace("https://", "");
                return new Channel(newConString, new SslCredentials());
            }
