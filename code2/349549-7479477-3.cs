    public class StreamState
    {
        public byte[] Buffer { get; set; }
        public NetworkStream Stream { get; set; }
    }
    clientStream.BeginRead(buffer, 0, buffer.Length, Read, new StreamState { Buffer = buffer, Stream = clientStream });
    private void Read(IAsyncResult async)
    {
        StreamState state = (StreamState) async.AsyncState;
        int bytesRead = state.Stream.EndRead(async);
        if (bytesRead == 4)
        {
            int result = BitConverter.ToInt32(state.Buffer, 0);
            //..
        }
    }
