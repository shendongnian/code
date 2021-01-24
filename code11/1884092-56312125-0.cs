        Boolean isAvailable = true;
        public void Send(byte[] data)
        {
                if (!isAvailable)
                    return;
                isAvailable = false;
            _socket.BeginSend(data, 0, data.Length, SocketFlags.None, (ar) =>
            {     
                _socket.EndSend(ar);
                isAvailable = true;
            }, state);
        }
