    public class Conversation 
    {
        public IEnumerable<Message> Messages {get;set;}
    }
    public class Message
    {
        public string From {get;set;}
        public IEnumerable<TypeWriter> TypeWriters {get;set;}
    }
