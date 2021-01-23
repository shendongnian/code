    public class MvcMessage
    {
        public object Source { get; private set; }
        public MessageType MessageType { get; private set; }
        public Type EntityType { get; private set; }
    
        public IList InvolvedItems { get; set; }
        public int NumAffected { get; set; }
        public EventArgs SourceEventArgs { get; internal set; }
    
        /// <summary>
        /// Name of property who changed its value. Applies to models implementing INotifyPropertyChanged.
        /// </summary>
        public string PropertyName { get; set; }
    
        public MvcMessage(object source, MessageType messageType, Type entityType)
        {
            this.Source = source;
            this.MessageType = messageType;
            this.EntityType = entityType;
        }
    
        public void Reroute(Type newEntityType)
        {
            MvcMessage reroutedMessage = (MvcMessage)MemberwiseClone();
            reroutedMessage.EntityType = newEntityType;
            Controller.NotifyAll(reroutedMessage);
        }
    }
