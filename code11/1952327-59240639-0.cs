    public enum MessageTypes
    {
        Msg1 = 1,
        Msg2 = 2
    }
    public class PayLoad
    {
        public int Foo { get; set; }
        public Rectangle Rectangle { get; set; }
    }
    public class Bar
    {
        public MessageTypes MessageType { get; set; }
        public PayLoad Payload { get; set; }
    }
