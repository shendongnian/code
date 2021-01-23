    [MapField("MaxCount", "Rule.MaxCount")]
    [MapField("MinSpace", "Rule.MinSpace")]
    public class MyEntity
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        [NoInstance] // this will make it work
        public MyEntityRule Rule { get; set; }
    
        public bool HasRule
        {
            get { return this.Rule != null; }
        }
    }
