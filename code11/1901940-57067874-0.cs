    public abstract class ValueThatInvokesMethodWhenItsUpdated<T>
    {
        private T _value;
        
        public T Value => _value;
        public void SetValue(T value)
        {
            _value = value;
            ExtraWork();
        }
        protected abstract void ExtraWork();
    }
