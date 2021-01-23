    public abstract class Problem<T>
    {
        public abstract int ResultCount { get; }
        public abstract bool CheckTheAnswer(params decimal[] results);
    }
