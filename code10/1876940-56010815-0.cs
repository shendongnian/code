    public class Interpreter
    {
        private readonly Dictionary<Type, Stack> _stacksByType = new Dictionary<Type, Stack>();
        public void Push<T>(T item) 
        {
            if (!_stacksByType.ContainsKey(typeof(T)))
            {
                _stacksByType.Add(typeof(T), new Stack());
            }
            _stacksByType[typeof(T)].Push(item);
        }
        public T Pop<T>()
        {
            // If we pop an empty stack it throws an InvalidOperationException
            // so I'm throwing the same exception if there's no corresponding stack.
            if (!_stacksByType.ContainsKey(typeof(T)))
                throw new InvalidOperationException("There is nothing in the stack.");
            return (T)_stacksByType[typeof(T)].Pop();
        }
    }
