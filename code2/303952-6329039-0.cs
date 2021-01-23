    public abstract class MessageBase
    {
        public RequestState RequestState { get; set; }
        public string Message { get; set; }
    }
    
    
    public class Contacts : MessageBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
