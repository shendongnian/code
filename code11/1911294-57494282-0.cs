    public abstract class FuncHolder<T, TResult>
    {
        public abstract Func<T, TResult> Value { get; }
    }
    public static class FuncHolder
    {
        private static readonly Dictionary<int, Delegate> MetadataTokenToMethodDictionary = new Dictionary<int, Delegate>();
        private class FuncHolderImplementation<T, TResult> : FuncHolder<T, TResult>
        {
            public int MetadataToken { get; }
            public FuncHolderImplementation(int metadataToken)
            {
                MetadataToken = metadataToken;
            }
            public override Func<T, TResult> Value => (Func<T, TResult>) MetadataTokenToMethodDictionary[MetadataToken];
        }
        public static FuncHolder<T, TResult> GetFuncHolder<T, TResult>(Func<T, TResult> func)
        {
            if (!MetadataTokenToMethodDictionary.ContainsKey(func.Method.MetadataToken))
            {
                MetadataTokenToMethodDictionary[func.Method.MetadataToken] = func;
            }
            return new FuncHolderImplementation<T, TResult>(func.Method.MetadataToken);
        }
    }
