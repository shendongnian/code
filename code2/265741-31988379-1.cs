    public interface IId<T>
    {
        int Value { get; }
    }
    public static class Id
    {
        public static IId<T> Create<T>(int value)
        {
            return new IdImpl<T>(value);
        }
        internal struct IdImpl<T> : IId<T>
        {
            public IdImpl(int value)
            {
                this.Value = value;
            }
            public int Value { get; }
            /* Implement equality comparer here */
        } 
    }
