     public class SessionData{
          public DateTime Start { get; set; }
          public string IpAddress { get; set; }
     }
     public class Session { 
          public static readonly AbstractFactory<SessionData,Session> Factory = AbstractFactory<Session>.GetInstance();
          private readonly string _ip;
          private readonly DateTime _start;
          public Session(SessionData data) { 
               _ip = data.IpAddress;
               _start = DateTime.Now;
          }
          public event EventHandler<RequestReceivedEventEventArgs> RequestAdded;
     }
     public class RequestReceivedEventArgs:  EventArgs { 
         public SessionRequest Request { get; set; }
     }
    public class TcpServer : ITcpServer
    {
        private readonly Processor _processor;
    
        public TcpServer(Processor processor)
        {
            this._processor = processor;
        }
        public void OnConnectionReceived()
        {
           var sessionData = new SessionData { 
                                                IpAddress = ip.LocalEndPoint(),
                                                Start = DateTime.Now
                                              };
           var session = Session.Factory.Create(sessionData);
           //...do other stuff
        }
        public void ServeResponse(SessionRequest request){
                _processor.Process(request);
        }
    }  
