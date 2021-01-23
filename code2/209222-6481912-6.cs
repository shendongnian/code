    public class LazyProperty<T>
    {
        bool _initialized = false;
        T _result;
        public T Value(Func<T> fn)
        {
			if (!_initialized)
			{
				_result = fn();
				_initialized = true;
			}
			return _result;
        }
     }
