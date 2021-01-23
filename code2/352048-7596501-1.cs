    public class ChatHandler : WebSocketHandler
    {
        private JavaScriptSerializer serializer = new JavaScriptSerializer();
        private static WebSocketCollection chatapp = new WebSocketCollection();
    
        public override void OnMessage(string message)
        {
            var m = serializer.Deserialize<Message>(message);
    
            switch (m.Type)
            {
                case MessageType.NewUser:
                    chatapp.Broadcast(serializer.Serialize(new
                    {
                        type = "newUser",
                        username = m.username
                    }));
    
                    break;
                case MessageType.Message:
                    chatapp.Broadcast(serializer.Serialize(new
                    {
                        type = "message",
                        message = m.message
                    }));
    
                    break;
                default:
                    return;
            }
        }
    }
