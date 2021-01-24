    public class RequestModel<T>
    {
        public Guid Id { get; set; }
        public T Model { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public DateTime LogDate { get; set; }
        public RequestModel()
        {
            Id = Guid.NewGuid();
        }
    }
