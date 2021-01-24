       interface IMessage
        {
        }
    
        interface IMessageProtocolv1 : IMessage
        {
            string sender { get; set; }
            int message_id { get; set; }
            string text { get; set; }
            int priority { get; set; }
            List<string> parameters { get; set; }
    
        }
    
        interface IMessageProtocolv2 : IMessage
        { 
            int id { get; set; }
            int someotherid { get; set; }
            List<string> data { get; set; }
    
        }
    
        abstract class MessageBase : IMessageProtocolv1, IMessageProtocolv2
        {
            public abstract string sender { get; set; }
            public abstract int message_id { get; set; }
            public abstract string text { get; set; }
            public abstract int priority { get; set; }
            public abstract List<string> parameters { get; set; }
            public abstract int id { get; set; }
            public abstract int someotherid { get; set; }
            public abstract List<string> data { get; set; }
        }
    
        class Message : MessageBase
        {
            public Message()
            {
                this.parameters = new List<string>();
                this.data = new List<string>();
            }
    
            public override string sender { get; set; }
            public override int message_id { get; set; }
            public override string text { get; set; }
            public override int priority { get; set; }
            public override List<string> parameters { get; set; }
            public override int id { get; set; }
            public override int someotherid { get; set; }
            public override List<string> data { get; set; }
    
            public T GetProtocol<T>() 
            {
                return (T)(object)this;
            }
        }
