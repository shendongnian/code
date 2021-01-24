    public class Relation
    {
        public Relation(int sourceId, int targetId)
        {
            SourceId = sourceId;
            TargetId = targetId;
        }
        public Int32 SourceId { get; set; }
        public Int32 TargetId { get; set; }
    }
