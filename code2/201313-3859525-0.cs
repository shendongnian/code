    public class MessageGroups : IMessageGroups
    {
        private readonly IEnumerable<IGrouping<MessageType, Message>> _groups;
    
        public MessageGroups(IEnumerable<IGrouping<MessageType, Message>> groups)
        {
            _groups = groups;
        }
    
        public IEnumerable<IGrouping<MessageType, Message>> GetEnumerator()
        {
            return _groups.GetEnumerator();
        }
    
        public static MessageGroups Create(IEnumerable<IGrouping<MessageType, Message>> groups)
        {
            return new MessageGroups(groups);
        }
    }
