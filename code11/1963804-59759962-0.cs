    public class CustomFilter : FilterSkeleton
    {
        private readonly IList<IFilter> _filters = new List<IFilter>();
        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (loggingEvent == null)
                throw new ArgumentNullException(nameof(loggingEvent));
            var properties = loggingEvent.GetProperties();
            if (properties != null && (properties[Key] as string ?? properties[Key]?.ToString()) == StringToMatch )
            {
                return AcceptOnMatch ? FilterDecision.Accept : FilterDecision.Deny;
            }
            if (_filters.All(x => x.Decide(loggingEvent) != FilterDecision.Accept))
            {
                return FilterDecision.Neutral;
            }
            // All conditions are true
            return AcceptOnMatch ? FilterDecision.Accept : FilterDecision.Deny;
        }
        public IFilter Filter
        {
            set => _filters.Add(value);
        }
        public bool AcceptOnMatch { get; set; }
        public string Key { get; set; }
        public string StringToMatch { get; set; }
    }
I have not tested it with multiple filters, but this is a start.
