    public class SocketWrapper
    {
        private readonly Socket _socket;
        public SocketWrapper(Socket socket)
        {
            _socket = socket;
        }
        public virtual EndPoint RemoteEndPoint
        {
            get { return _socket.RemoteEndPoint; }
        }
        public virtual void Close()
        {
            _socket.Close();
        }
        public virtual void EndDisconnect(IAsyncResult asyncResult)
        {
            _socket.EndDisconnect(asyncResult);
        }
        public virtual bool Connected
        {
            get { return _socket.Connected; }
        }
        public virtual int Send(byte[] data)
        {
            return _socket.Send(data);
        }
        public virtual IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags flags, AsyncCallback callback, object state )
        {
            return _socket.BeginReceive(buffer, offset, size, flags, callback, state);
        }
        public virtual int EndReceive(IAsyncResult asyncResutl)
        {
            return _socket.EndReceive(asyncResutl);
        }
        public virtual IAsyncResult BeginDisconnect(bool reuseSocket,AsyncCallback callback, object state)
        {
            return _socket.BeginDisconnect(reuseSocket, callback, state);
        }
    }
