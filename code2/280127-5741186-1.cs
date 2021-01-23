    class CustomActivator<T> where T : Serialization.ITcpSerializable<T>
    {
        public void ListenTo(AndroidTcpServer server)
        {
             server.TcpServerMessageReceived += DataReceived;
        }
        private void DataReceived(object sender, TcpServerMessageReceivedEventArgs e)
        {
            T res =  Activator.CreateInstance<T>();
            using (MemoryStream stream = new MemoryStream(e.Data))
            {
                OnObjectReceived(res.Deserialize(XElement.Load(stream));               
            }
        }
        protected void OnObjectReceived(T obj)
        {
            var handler = ObjectReceived;
            if (handler != null)
            {
                OnObjectReceived(this, new ObjectReceivedEventArgs(obj));
            }
        }
    }
