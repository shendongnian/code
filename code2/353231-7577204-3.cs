    public enum MessageType
    {
        None = 0,
        All,
        General,
        OfficeHoursUpdate,
        // …
    }
    [DataObject]
    public class MessagesDataSource : IDisposable
    {
        IMessagesService _svc = new MessagesServiceClient();
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Message> Select(string username, MessageType type, string sort, int skip, int take)
        {
            return _svc.GetMessages(username, type, sort, skip, take);
            
        }
        public int SelectCount(string username, MessageType type, string sort, int skip, int take)
        {
            return _svc.CountMessages(username, type);
        }
    }
