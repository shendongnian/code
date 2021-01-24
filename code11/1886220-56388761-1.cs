    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public char ServiceLetter { get; set; }
        public string ServiceName { get; set; }
    }
    public class MyQueue
    {
        public int MyQueueId { get; internal set; }
        public string Name { get; internal set; }
        
        public virtual Service Service { get; internal set; }
        // Persisted to the MyQueue table.
        public string QueueNumber { get; internal set; }
        
        public void UpdateService(Service service)
        {
            Service = service;
            QueueNumber = string.Format("{0}{1:000}", service?.ServiceLetter ?? "?", MyQueueId);
        }
    }
