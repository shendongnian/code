        static Delegate ConvertDelegate(Delegate src, Type targetType, bool doTypeCheck)
        {
            //Is it converting to itself or is null?
            if (src == null || src.GetType() == targetType)
                return src;
            //Is it multiple cast?
            if (src.GetInvocationList().Count() > 1)
                return src.GetInvocationList().Where(d => !d.Equals(src)).Aggregate<Delegate, Delegate>
                    (null, (current, d) => Delegate.Combine(current, ConvertDelegate(d)));
            return (src.Target == null
                ? Delegate.CreateDelegate(targetType, src.Method, doTypeCheck)
                : Delegate.CreateDelegate(targetType, src.Target, src.Method, doTypeCheck));
        }
