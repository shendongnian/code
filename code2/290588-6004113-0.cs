    public class WorkItem<T>
    {
        private StreamWriter resource;
        private T parameter;
        public WorkItem(StreamWriter resource, T parameter)
        {
            this.resource = resource;
            this.parameter = parameter;
        }
        public StreamWriter Resource { get { return resource; } }
        public T Parameter { get { return parameter; } }
    }
