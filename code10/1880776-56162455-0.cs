    class WebSocketHandler : IWebSocketRequestHandler
    {
        private Dictionary<string,WebSocket> _webSockets = new Dictionary<string, WebSocket>();
        public event MessageRecivedHandler MessageRecived;
        private IdHelper _portMappings;
        public WebSocketHandler(IdHelper portMappings)
        {
            _portMappings = portMappings;
        }
         
        
        public void Connected(WebSocket socket)
        {
            var guid = Guid.NewGuid().ToString();
            _webSockets.Add(guid, socket);
            
            socket.DataReceived += (webSocket, frame) => MessageRecived?.Invoke(_webSockets.First(x => x.Value == webSocket).Key,webSocket, frame);
            socket.ConnectionClosed += (webSocket) =>
            {
                var connection = _webSockets.First(s => s.Value == webSocket);
                _webSockets.Remove(connection.Key);
            };
            if (_portMappings.IsBindingPosible())
            {
                _portMappings.Bind(guid);
                var message = new ServerMessage()
                {
                    ClientID = guid,
                    Command = "Init",
                    Value = _portMappings.CheckBinding(guid).ToString()
                };
                SendMessage(guid, message);
            }
            else
            {
                var message = new ServerMessage()
                {
                    ClientID = guid,
                    Command = "Init",
                    Value = "Max Number Of Clients Reached. Please close connection"
                };
                SendMessage(guid, message);
            }
            
        }
        public bool WillAcceptRequest(string uri, string protocol)
        {
            return true;
        }
        public async Task BroadcastMessage(string message)
        {
            await ThreadPool.RunAsync((workItem) => _webSockets?.AsParallel().ForAll(webSocket => webSocket.Value.Send(message)));
        }
        public async Task SendMessage(string guid, ServerMessage message)
        {
            await ThreadPool.RunAsync((workItem) => _webSockets?.First(x => x.Key == guid).Value.Send(JsonConvert.SerializeObject(message)));
        }
        public delegate void MessageRecivedHandler(string guid, WebSocket socket, string message);
    }
