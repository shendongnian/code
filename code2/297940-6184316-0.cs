    public class MyClient
    {
        private readonly Queue<byte[]> _sendBuffers = new Queue<byte[]>();
        private bool _sending;
        private Socket _socket;
    
        public void Send(string cmdName, object data)
        {
            lock (_sendBuffers)
            {
                _sendBuffers.Enqueue(serializedCommand);
                if (_sending) 
                    return;
    
                _sending = true;
                ThreadPool.QueueUserWorkItem(SendFirstBuffer);
            }
        }
    
        private void SendFirstBuffer(object state)
        {
            while (true)
            {
                byte[] buffer;
                lock (_sendBuffers)
                {
                    if (_sendBuffers.Count == 0)
                    {
                        _sending = false;
                        return;
                    }
    
                    buffer = _sendBuffers.Dequeue();
                }
    
                _socket.Send(buffer);
            }
        }
    }
