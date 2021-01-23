    public class LazyProperty<T>
    {
        bool uninitialized = true;
        T _result;
        public T Value(Func<T> fn)
        {
                if (uninitialized)
                {
                    _result = fn();
                    uninitialized = false;
                }
                return _result;
        }
     }
