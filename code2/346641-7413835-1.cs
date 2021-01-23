public abstract class Either&lt;TLeft, TRight&gt;
{
    private Either()
    {
    }
    public static Either&lt;TLeft, TRight&gt; Create(TLeft value)
    {
        return new Left(value);
    }
    public static Either&lt;TLeft, TRight&gt; Create(TRight value)
    {
        return new Right(value);
    }
    public abstract TResult Match&lt;TResult&gt;(
        Func&lt;TLeft, TResult&gt; onLeft,
        Func&lt;TRight, TResult&gt; onRight);
    public sealed class Left : Either&lt;TLeft, TRight&gt;
    {
        public Left(TLeft value)
        {
            this.Value = value;
        }
        public TLeft Value
        {
            get;
            private set;
        }
        public override TResult Match&lt;TResult&gt;(
            Func&lt;TLeft, TResult&gt; onLeft,
            Func&lt;TRight, TResult&gt; onRight)
        {
            return onLeft(this.Value);
        }
    }
    public sealed class Right : Either&lt;TLeft, TRight&gt;
    {
        public Right(TRight value)
        {
            this.Value = value;
        }
        public TRight Value
        {
            get;
            private set;
        }
        public override TResult Match&lt;TResult&gt;(
            Func&lt;TLeft, TResult&gt; onLeft,
            Func&lt;TRight, TResult&gt; onRight)
        {
            return onRight(this.Value);
        }
    }
}
