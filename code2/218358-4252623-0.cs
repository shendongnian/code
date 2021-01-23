    public T Create<T>(params object[] parameters) 
    {
        T instance = _kernel.Get<T>();
        if (typeof(T) == typeof(FailResult))
        {
            FailResult result = (FailResult)instance;
            result.ErrorCode = (int)parameters[0];
            return result;
        }
    }
