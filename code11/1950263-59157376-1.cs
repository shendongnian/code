    public class Notification : INotification
    {
        public Notification(string id, int type, IList<Message> messages)
        {
            this.Id = id;
            this.Type = type;
            this.Messages = messages;
        }
        public string Id { get; set; }
        
        public int Type { get; set; }
        public IList<Message> Messages { get; set; }
    }
