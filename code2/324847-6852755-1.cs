    public interface IEither<TLeft, TRight>
    {
        TResult Map<TResult>(Func<TLeft, TResult> onLeft, Func<TRight, TResult> onRight);
        void Map(Action<TLeft> onLeft, Action<TRight> onRight);
    }
    public sealed class Left<TLeft, TRight> : IEither<TLeft, TRight>
    {
        private readonly TLeft value;
        
        public Left(TLeft value)
        {
            this.value = value;
        }
        
        public TResult Map<TResult>(Func<TLeft, TResult> onLeft, Func<TRight, TResult> onRight)
        {
            return onLeft(value);
        }
        public void Map(Action<TLeft> onLeft, Action<TRight> onRight)
        {
            onLeft(value);
        }
    }
    
    public sealed class Right<TLeft, TRight> : IEither<TLeft, TRight>
    {
        private readonly TRight value;
        public Right(TRight value)
        {
            this.value = value;
        }
        public TResult Map<TResult>(Func<TLeft, TResult> onLeft, Func<TRight, TResult> onRight)
        {
            return onRight(value);
        }
        public void Map(Action<TLeft> onLeft, Action<TRight> onRight)
        {
            onRight(value);
        }
    }
