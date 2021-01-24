    public class Service
    {
        [Key]
        public char ServiceLetter { get; set; }
        public string ServiceName { get; set; }
    }
    public class MyQueue
    {
        public int MyQueueId { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("Service")]
        public char? ServiceLetter { get; set; }
        public virtual Service Service { get; set; }
        [NotMapped]
        public string QueueNumber
        {
            get
            {
                return string.Format("{0}{1:000}", ServiceLetter.HasValue ? ServiceLetter.Value : "?", MyQueueId);
            }
        }
    }
