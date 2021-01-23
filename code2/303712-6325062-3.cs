    internal class Proxy : MarshalByRefObject
    {
        private AppController _AppController;
        public void Initialize(string assemblyFile)
        {
            Assembly asm = Assembly.LoadFile(assemblyFile);
            var q = from t in asm.GetTypes()
                    where t.GetInterfaces().Contains(typeof(AppController))
                          && !t.IsAbstract && t.IsClass
                    select t;
            foreach (Type t in q)
            {
                _AppController = (AppController)Activator.CreateInstance(t);
            }
        }
        public void SendResponse(SocketInformation clientInfo, HttpRequest req)
        {
            Socket client = new Socket(clientInfo);
            LinkedList<byte[]> toSend = _AppController.GetResponse(clientInfo, req);
            foreach (byte[] bytes in toSend)
                client.Send(bytes);
            client.Close();
        }
    }
