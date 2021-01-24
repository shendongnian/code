    public class PivotGroup
    {
        public string Key { get; set; }
        public List<PivotGroup> ChildGroups { get; } = new List<PivotGroup>();
        public override string ToString() => Key; // Makes debugging easier.
    }
