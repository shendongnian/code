       public class UserMessage 
        {
            public override DateTime MessageTimestamp { get; set; }
            public override string MessageId { get; set; }
    
            [ProtoMember(35)]
            public string UserName { get; set; }
    
            [ProtoMember(34)]
            public string RealName { get; set; }
        }
    
        public class UserMessageForLog
        {
            public UserMessageForLog(UserMessage msg)
            {
                MessageTimestamp = msg.MessageTimestamp;
                MessageId = msg.MessageId;
                UserName = msg.UserName;
            }
    
            public  DateTime MessageTimestamp { get; set; }
            public  string MessageId { get; set; }
            public string UserName { get; set; }
        }
    
        public LogUserMessage(UserMessageForLog msg)
        {
    
    
        }
   
