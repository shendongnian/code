    public class AdvancedStats
    {
        public double Prop1 { get; set; }
        public double Prop2 { get; set; }
        public double Prop3 { get; set; }
    }
    
    public class AdvancedRoot
    {
    	[JsonProperty("advanced-stats")]
    	public AdvancedStats AdvancedStats { get; set; }
    }
