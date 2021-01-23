    public class ChatMessage
    {
        public string Message { get; set; }
        public DateTime DateReceived { get; set; }
    
        public override string ToString()
        {
            return Message;
        }
        
        public ChatMessage()
        {
            Message = "Testing Message";
            DateReceived = new DateTime(2011, 07, 16, 14, 00, 05);
        }
    }
