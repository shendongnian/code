    [ProtoContract]
    public class FakeSimpleEvent
        : IPersistableEvent
    {
        [ProtoMember(1)]
        public Guid AggregateId { get; }
        [ProtoMember(2)]
        public string Value { get; }
        public FakeSimpleEvent(Guid aggregateId, string value)
        {
            AggregateId = aggregateId;
            Value = value;
        }
    }
