    public class TimedEvent<T>
    {
        public int ExecutionTime { get; set; }
        public EventKinds EventKind { get; set; }
        public EventStatusKinds Status { get; set; }
        public T Data { get; set; }
	}
