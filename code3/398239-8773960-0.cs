    void Register<T>(Action<T> action, bool invokeOnTypeMismatch = false)
        where T : IMessage
    {
        Action<IMessage> wrapped = (msg) =>
            {
                if (msg is T)
                {
                    action((T)msg);
                }
                else if (invokeOnTypeMismatch)
                {
                    action(default(T));
                }
            };
        method.Add(wrapped);
    }
