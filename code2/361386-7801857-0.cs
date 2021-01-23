    public static Maybe<T> TryGet<T>(this Maybe<T> m, Func<T> getFunction)
    {
        // If m has a value, just return m - we want to return the value
        // of the *first* successful TryGet.
        if (m.HasValue)
        {
            return m;
        }
        try
        {
            var value = getFunction();
            // We were able to successfully get a value. Wrap it in a Maybe
            // so that we can continue to chain.
            return value.ToMaybe();
        }
        catch
        {
            // We were unable to get a value. There's nothing else we can do.
            // Hopefully, another TryGet or ThrowIfNone will handle the None.
            return Maybe<T>.None;
        }
    }
    public static Maybe<T> ThrowIfNone<T>(
        this Maybe<T> m,
        Func<Exception> throwFunction)
    {
        if (!m.HasValue)
        {
            // If m does not have a value by now, give up and throw.
            throw throwFunction();
        }
        // Otherwise, pass it on - someone else should unwrap the Maybe and
        // use its value.
        return m;
    }
