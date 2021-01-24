    public void Send(byte[] data)
        {
            if (ClientSocket != null && ClientSocket.Connected)
            {
                ClientSocket.BeginSend(AddSize(data), 0, data.Length, 0, ResponseSend, this);
            }
            else
            {
                ConnectionFailed();
            }
        }
