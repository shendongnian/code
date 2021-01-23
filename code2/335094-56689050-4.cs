    public class FakeSimpleEvent
        : IPersistableEvent
    {
        public Guid AggregateId { get; }
        public string Value { get; }
        public FakeSimpleEvent(Guid aggregateId, string value)
        {
            AggregateId = aggregateId;
            Value = value;
        }
    }
