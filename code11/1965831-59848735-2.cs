    public static class ExecutionExtensions
    {
        public static void Execute(this IEnumerable<Action> pipeline, Func<bool> cancellationFunction)
        {
            foreach (var action in pipeline)
            {
                action();
                if (cancellationFunction())
                    break;
            }
        }
    }
