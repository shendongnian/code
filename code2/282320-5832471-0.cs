    public abstract class LineBasedChannel
    {	
    	Socket _socket;
        string _inbuffer = string.Empty;
        Encoding _encoding;
    	byte[] _buffer = new byte[8192];
    	
    	public LineBasedChannel(Socket socket)
    	{
    		_socket = socket;
    		_encoding = Encoding.ASCII;
    		_sb = new StringBuilder();
    	}
    
        public void Start()
    	{
    	    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,OnRead, null);
    	}
    	
    	public void OnRead(IAsyncResult res)
    	{
    		var bytesRead = _socket.EndReceive(res);
    		if (bytesRead == 0)
    		{
    			HandleDisconnect();
    			return;
    		}
    		
    		_inbuffer += _encoding.GetString(_buffer, 0, bytesRead);
    		_socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,OnRead, null);
    		
    		while (true)
    		{
    			int pos = _inbuffer.IndexOf("\r\n");
    			if (pos == -1)
    				break;
    				
    			OnReceivedLine(_inbuffer.SubString(0, pos+2);
    			_inbuffer = _inbuffer.Remove(0,pos+1);
    		}
    	}
    	
    	protected abstract void OnReceivedLine(string line);
    }
    
    public class IrcTcpChannel : LineBasedChannel
    {
        protected override void OnReceivedLine(string line)
    	{
    		var cmd = new IrcCommand();
    		cmd.Channel = line.SubString(x,y);
    		cmd.Message = line.SubString(z,a);
    		CommandReceived(this, new IrcCommandEventArgs(cmd));
    	}
        public event EventHandler<IrcCommandEventArgs> CommandReceived = delegate {};
    }
