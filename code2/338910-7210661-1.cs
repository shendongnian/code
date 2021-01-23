    public abstract class ProblemBase
    {
        public abstract ResultBase Result { get; }
    }
    public abstract class ProblemBase<TResult> : ProblemBase
        where TResult : ResultBase
    {
        public override ResultBase Result { get { return Result; } }
        new public TResult Result { get; private set; }
    }
