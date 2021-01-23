    public abstract class ProblemBase
    {
        public abstract object Result { get; }
    }
    public abstract class ProblemBase<TResult> : ProblemBase
    {
        public override object Result
        {
            get { return Result; }
        }
        new public TResult Result { get; private set; }
    }
