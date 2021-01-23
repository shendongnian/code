    public class NodeIdGenerator
    {
        protected virtual int? PreviousId { ... }
    }
    
    private class NodeIdGeneratorMock : NodeIdGenerator
    {
        protected override int? PreviousId
        {
            get { return _previousId; }
        }
    }
