    public class UserMessage : IUserMessageForClients
    {
        public override DateTime MessageTimestamp { get; set; }
        public override string MessageId { get; set; }
        [ProtoMember(35)]
        public string UserName { get; set; }
        [ProtoMember(34)]
        public string RealName { get; set; }
    }
    
    public interface IUserMessageForClients
    {
      DateTime MessageTimestamp { get; set; }
      string MessageId { get; set; }
      string UserName { get; set; }
    }
    public LogUserMessage(IUserMessageForClients msg){
    
     
    }
