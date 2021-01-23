    class ConsoleHost : IDisposable
    {
        public static Uri BaseAddress = new Uri(http://localhost:8161/MyService/mex);
        private ServiceHost host;
        public void Start(Uri baseAddress)
        {
            if (host != null) return;
            host = new ServiceHost(typeof(MyService), baseAddress ?? BaseAddress);
            //binding
            var binding = new BasicHttpBinding()
            {
                Name = "MyService",
                MessageEncoding = WSMessageEncoding.Text,
                TextEncoding = Encoding.UTF8,
                MaxBufferPoolSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            host.Description.Endpoints.Clear();
            host.AddServiceEndpoint(typeof(IMyService), binding, baseAddress ?? BaseAddress);
            // Enable metadata publishing.
            var smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 },
            };
            host.Description.Behaviors.Add(smb);
            var defaultBehaviour = host.Description.Behaviors.OfType<ServiceDebugBehavior>().FirstOrDefault();
            if (defaultBehaviour != null)
            {
                defaultBehaviour.IncludeExceptionDetailInFaults = true;
            }
 
            host.Open();
        }
        public void Stop()
        {
            if (host == null)
                return;
            host.Close();
            host = null;
        }
        public void Dispose()
        {
            this.Stop();
        }
    }
