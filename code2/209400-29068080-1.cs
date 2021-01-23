    public static Delegate ConvertDelegate(Delegate src, Type targetType, bool doTypeCheck)
    {
        //Is it null or of the same type as the target?
        if (src == null || src.GetType() == targetType)
            return src;
        //Is it multiple cast?
        return src.GetInvocationList().Count() == 1
            ? Delegate.CreateDelegate(targetType, src.Target, src.Method, doTypeCheck)
            : src.GetInvocationList().Aggregate<Delegate, Delegate>
                (null, (current, d) => Delegate.Combine(current, ConvertDelegate(d)));
    }
