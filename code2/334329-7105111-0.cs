    private void BeginReceiveBuffer()
    {
       _socket.BeginReceive(buffer, 0, buffer.Length, BufferEndReceive, buffer);
    }
    private void EndReceiveBuffer(IAsyncState state)
    {
       var buffer = (byte[])state.AsyncState; // This is the last parameter.
       var length = _socket.EndReceive(state); // This is the return value of the method call.
       DataReceived(buffer, 0, length); // Do something with the data.
    }
