    internal static void ShowValue()
    {
        if (_val == null)
        {
            if (typeof(T).TypeInitializer != null)
                typeof(T).TypeInitializer.Invoke(null, null);
            if (_val == null)
                throw new InvalidOperationException(string.Format("The type initializer of {0} did not initialize the _val field.", typeof(T)));
        }
        Console.WriteLine(_val);
    }
