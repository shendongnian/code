    internal class Sandbox
    {
        public Sandbox(string assemblyFile)
        {
            _AppDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            _Proxy = (WebApplicationProxy)_AppDomain.CreateInstanceAndUnwrap(
                                                        Assembly.GetExecutingAssembly().FullName,
                                                        "WebServer.WebApplication.Proxy");
            _Proxy.Initialize(assemblyFile);
        }
        public void SendResponse(Socket client, HttpRequest request)
        {
            SocketInformation clientInfo = client.DuplicateAndClose(Process.GetCurrentProcess().Id);
            _Proxy.GetResponse(clientInfo, request);
        }
    }
