    class GenericActivator
    {
        public void ListenTo(AndroidTcpServer server)
        {
             server.TcpServerMessageReceived += DataReceived;
        }
        private void DataReceived(object sender, TcpServerMessageReceivedEventArgs e)
        {
            var t = Type.GetType(GuessTypeName(e.Data));
            
            var res =  Activator.CreateInstance(t) as typeof(ITcpSerializable<>).MakeGenericType(t);
            using (MemoryStream stream = new MemoryStream(e.Data))
            {
                OnObjectReceived(res.Deserialize(XElement.Load(stream));               
            }
        }
        protected void OnObjectReceived(object obj)
        {
            var handler = ObjectReceived;
            if (handler != null)
            {
                OnObjectReceived(this, new ObjectReceivedEventArgs(obj));
            }
        }
    }
