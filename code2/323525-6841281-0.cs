    public class Strategy<TInput, TOutput>
    {
        public Predicate<TInput> Condition { get; private set; }
        public Func<TInput, TOutput> Result { get; private set; }
        public Strategy(Predicate<TInput> condition, Func<TInput, TOutput> result)
        {
            Condition = condition;
            Result = result;
        }
        public TOutput Evaluate(TInput input)
        {
            return Condition(input) ? Result(input) : default(TOutput);
        }
    }
