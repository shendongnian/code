    public class HttpsClientHandler : AndroidClientHandler
    {
        private static readonly Logger LOG = LogManager.GetLogger();
        private SSLContext sslContext;
        private readonly ITrustManager[] trustManagers;
        private IKeyManager[] keyManagers = null;
        public HttpsClientHandler() : base()
        {
            trustManagers = GetTrustManagers();
            sslContext = GetSSLContext();
        }
        private SSLContext GetSSLContext()
        {
            string protocol;
            if (SslProtocols == SslProtocols.Tls11)
            {
                protocol = "TLSv1.1";
            } else if (SslProtocols == SslProtocols.Tls || SslProtocols == SslProtocols.Tls12)
            {
                protocol = "TLSv1.2";
            } else
            {
                throw new IOException("unsupported ssl protocol: " + SslProtocols.ToString());
            }
            SSLContext ctx = SSLContext.GetInstance(protocol);
            ctx.Init(keyManagers, trustManagers, null);
            return ctx;
        }
        public new SslProtocols SslProtocols { get; set; } = SslProtocols.Tls12;
        public void SetClientCertificate(byte[] pkcs12, char[] password)
        {
            keyManagers = GetKeyManagersFromClientCert(pkcs12, password);
            SSLContext newContext = GetSSLContext();
            sslContext = newContext;
        }
        private ITrustManager[] GetTrustManagers()
        {
            TrustManagerFactory trustManagerFactory = TrustManagerFactory.GetInstance(TrustManagerFactory.DefaultAlgorithm);
            trustManagerFactory.Init((KeyStore)null);
            return trustManagerFactory.GetTrustManagers();
        }
        private IKeyManager[] GetKeyManagersFromClientCert(byte[] pkcs12, char[] password)
        {
            if (pkcs12 != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(pkcs12))
                {
                    KeyStore keyStore = KeyStore.GetInstance("pkcs12");
                    keyStore.Load(memoryStream, password);
                    KeyManagerFactory kmf = KeyManagerFactory.GetInstance("x509");
                    kmf.Init(keyStore, password);
                    return kmf.GetKeyManagers();
                }
            }
            return null;
        }
        protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
        {
            SSLSocketFactory socketFactory = sslContext.SocketFactory;
            if (connection != null)
            {
                connection.SSLSocketFactory = socketFactory;
            }
            return socketFactory;
        }
    }
