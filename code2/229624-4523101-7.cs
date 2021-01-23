    interface IImmutableList<T>
    {
        public IImmutableList<T> Append(T newItem);
        public IImmutableList<T> RemoveLast();
        public T LastItem { get; }
        // and so on
    }
    sealed class ImList<T> : ImmutableList<T>
    {
        public static ImList<T> Empty = whatever;
        // etc
    }
