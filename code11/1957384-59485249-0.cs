        public class ClientMessageLogger : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                string displayText = $"the client has received the reply:\n{reply}\n";
                Console.Write(displayText);
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
                string displayText = $"the client send request message:\n{request}\n";
                Console.WriteLine(displayText);
                return null;
            }
    }
