    public class Descriptor<T>
    {
        private readonly string _description;
        private readonly Func<T> _create;
        public Descriptor(string description, Func<T> create)
        {
            _description = description;
            _create = create;
        }
        public string Description { get { return _description; } }
        public T Create() { return _create(); }
    }
