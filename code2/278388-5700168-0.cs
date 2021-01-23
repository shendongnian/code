    public class ValidationException : Exception {
        private readonly object _Field;
        public object Field { get { return _Field; } }
    
        public ValidationException(string message) : base(message) { }
        
        public ValidationException(string message, object field)
            : this(message) {
            _Field = field;
        }
    }
