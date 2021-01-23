    public class Context<TInput, TOutput>
    {
        private List<Strategy<TInput, TOutput>> Strategies { get; set; }
        public Context(params Strategy<TInput, TOutput>[] strategies)
        {
            Strategies = strategies.ToList();
        }
        public TOutput Evaluate(TInput input)
        {
            var result = default(TOutput);
            foreach (var strategy in Strategies)
            {
                result = strategy.Evaluate(input);
                if (!Equals(result, default(TOutput)))
                    break;
            }
            return result;
        }
    }
