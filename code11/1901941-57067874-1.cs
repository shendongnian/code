    public class ValueThatInvokesMethodWhenItsUpdated<T>
    {
        private T _value;
        private readonly Action _extraWork;
        public ValueThatInvokesMethodWhenItsUpdated
            (Action extraWork)
        {
            _extraWork = extraWork;
        }
        public T Value => _value;
        public void SetValue(T value)
        {
            _value = value;
            _extraWork?.Invoke();
        }
    }
