    public static class PositionalParameterExtensions
    {
        public static IEnumerable<PositionalParameter> From(params Object[] args)
        {
            return args.Select((o, i) => new PositionalParameter(i, o)); 
        }
    }
