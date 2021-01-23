    namespace System.Net.Sockets
    {
        public class TcpConnection : IDisposable
        {
            public event EvHandler<TcpConnection, DataArrivedEventArgs> DataArrive = delegate { };
            public event EvHandler<TcpConnection> Drop = delegate { };
    
            private const int IntSize = 4;
            private const int BufferSize = 8 * 1024;
    
            private static readonly SynchronizationContext _syncContext = SynchronizationContext.Current;
            private readonly TcpClient _tcpClient;
            private readonly object _droppedRoot = new object();
            private bool _dropped;
            private byte[] _incomingData = new byte[0];
            private Nullable<int> _objectDataLength;
    
            public TcpClient TcpClient { get { return _tcpClient; } }
            public bool Dropped { get { return _dropped; } }
    
            private void DropConnection()
            {
                lock (_droppedRoot)
                {
                    if (Dropped)
                        return;
    
                    _dropped = true;
                }
    
                _tcpClient.Close();
                _syncContext.Post(delegate { Drop(this); }, null);
            }
    
            public void SendData(PCmds pCmd) { SendDataInternal(new object[] { pCmd }); }
            public void SendData(PCmds pCmd, object[] datas)
            {
                datas.ThrowIfNull();
                SendDataInternal(new object[] { pCmd }.Append(datas));
            }
            private void SendDataInternal(object data)
            {
                if (Dropped)
                    return;
    
                byte[] bytedata;
    
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
    
                    try { bf.Serialize(ms, data); }
                    catch { return; }
    
                    bytedata = ms.ToArray();
                }
    
                try
                {
                    lock (_tcpClient)
                    {
                        TcpClient.Client.BeginSend(BitConverter.GetBytes(bytedata.Length), 0, IntSize, SocketFlags.None, EndSend, null);
                        TcpClient.Client.BeginSend(bytedata, 0, bytedata.Length, SocketFlags.None, EndSend, null);
                    }
                }
                catch { DropConnection(); }
            }
            private void EndSend(IAsyncResult ar)
            {
                try { TcpClient.Client.EndSend(ar); }
                catch { }
            }
    
            public TcpConnection(TcpClient tcpClient)
            {
                _tcpClient = tcpClient;
                StartReceive();
            }
    
            private void StartReceive()
            {
                byte[] buffer = new byte[BufferSize];
    
                try
                {
                    _tcpClient.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceived, buffer);
                }
                catch { DropConnection(); }
            }
    
            private void DataReceived(IAsyncResult ar)
            {
                if (Dropped)
                    return;
    
                int dataRead;
    
                try { dataRead = TcpClient.Client.EndReceive(ar); }
                catch
                {
                    DropConnection();
                    return;
                }
    
                if (dataRead == 0)
                {
                    DropConnection();
                    return;
                }
    
                byte[] byteData = ar.AsyncState as byte[];
                _incomingData = _incomingData.Append(byteData.Take(dataRead).ToArray());
                bool exitWhile = false;
    
                while (exitWhile)
                {
                    exitWhile = true;
    
                    if (_objectDataLength.HasValue)
                    {
                        if (_incomingData.Length >= _objectDataLength.Value)
                        {
                            object data;
                            BinaryFormatter bf = new BinaryFormatter();
    
                            using (MemoryStream ms = new MemoryStream(_incomingData, 0, _objectDataLength.Value))
                                try { data = bf.Deserialize(ms); }
                                catch
                                {
                                    SendData(PCmds.Disconnect);
                                    DropConnection();
                                    return;
                                }
    
                            _syncContext.Post(delegate(object T)
                            {
                                try { DataArrive(this, new DataArrivedEventArgs(T)); }
                                catch { DropConnection(); }
                            }, data);
    
                            _incomingData = _incomingData.TrimLeft(_objectDataLength.Value);
                            _objectDataLength = null;
                            exitWhile = false;
                        }
                    }
                    else
                        if (_incomingData.Length >= IntSize)
                        {
                            _objectDataLength = BitConverter.ToInt32(_incomingData.TakeLeft(IntSize), 0);
                            _incomingData = _incomingData.TrimLeft(IntSize);
                            exitWhile = false;
                        }
                }
                StartReceive();
            }
    
    
            public void Dispose() { DropConnection(); }
        }
    }
