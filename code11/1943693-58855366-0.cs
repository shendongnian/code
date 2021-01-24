public class MySocket : IDisposable
{
    private Socket _socket;
    private bool _disposed = false;
    public MySocket(AddressFamily addressFamily)
    {
        _socket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
    }
    public void Dispose()
    {
        _socket.Dispose();
        _disposed = true;
    }
}
Indeed, many coding standards mandate that unmanaged resources **must** be wrapped in a `SafeHandle`. If you do this, there's no need to ever implement the full Dispose pattern.
If you **do** need to implement the full dispose pattern, you also need to write a finalizer. The code in your question doesn't do this.
