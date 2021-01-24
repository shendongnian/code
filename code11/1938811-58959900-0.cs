List<Socket> SocketList = new List<Socket>();
List<int> PortList = new List<int> (3) { 48005, 48006, 48007 };
public class State
{
    public int index = 0;
    public int port;
}
void FunServer ()
{
     for (int ii = 0; ii < PortList.Count; ii++)
     {
          Socket _s = new Socket(SocketType.Stream, ProtocolType.Tcp);
          _s.Blocking = false;
          IPEndPoint _endPoint = new IPEndPoint(IPAddress.Any, PortList[ii]);
          try
          {
              _s.Bind(endPoint); //Associates socket with a local endpoint
              _s.Listen(10);
              State _state = new State();
              _state.index = ii;
              _state.port = PortList[ii];  
              Console.WriteLine("Waiting for a connection...");
              _s.BeginAccept(new AsyncCallback(ListeningFun), _state);
              SocketList.Add(_s);
          }
          catch(Exception e)
          {
          }
     }
}
void ListeningFun(IAsyncResult ar)
{
     var _state = ar.AsyncState as State;
     var _port = state.port;
     try
     {
         Socket _s = SocketList[state.index].EndAccept(ar);
         // some more code here with the _s socket...
     }
     catch (ObjectDisposedException)
     {
         System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
     }
}
