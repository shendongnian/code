        public class ChatRoom
        {
            private readonly ILogger _logger;
            private XmppClient _client;
            private MucManager _mucManager;
            
            public ChatRoom(ILogger logger)
            {
                _logger = logger;           
            }
    
            public string UserName { get; set; }
            public string Password { get; set; }
            public string XmppDomain { get; set; }
            public System.Uri BoshUri { get; set; }
            public string RoomJid { get; set; }
            public string RoomNick { get; set; }
    
            public void Start()
            {
                _client = new XmppClient(UserName, XmppDomain, Password);               
                _client.OnBind += (o, e) => _CreateChatRoom(_client, RoomJid, RoomNick);
                _client.OnSendXml += (o, e) => Trace(ConsoleColor.DarkGreen, "Sending:\n {0}", e.Text);
                _client.OnReceiveXml += (o, e) => Trace(ConsoleColor.DarkMagenta, "Receiving:\n {0}", e.Text);
                _client.OnError += (o, e) => Trace(ConsoleColor.Red, "Error: {0}", e.Exception);
                _client.Open();
                _client.Close(); 
            }
            private void Trace(ConsoleColor color, string msg, params object[] args)
            {
                var oldColor = _logger.Color;
                _logger.Color = color;
                _logger.Log(msg, args);
                _logger.Color = oldColor;
                Debug.WriteLine(msg, args);
            }
    
            private void _CreateChatRoom(XmppClient client, string chatRoomName, string roomNick)
            {
                _mucManager = new MucManager(client);
                _mucManager.EnterRoom(chatRoomName, roomNick);            
            }
    
            public void SendMessage(string text)
            {
                _client.Send(new Message("muc@conference.dgwbhbm1", MessageType.groupchat, text));
            }
    
            public void End()
            {
                _client.Close();
            }
    
            public void Invite(Jid[] user)
            {
                _mucManager.Invite(user, RoomJid, "Come chat");
            }      
        }
