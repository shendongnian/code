    public class Root
    {
    	public Dictionary<string, Test> Topics { get; set; }
    }
    
    public class Test
    {
    	public string Topic { get; set; }
    	public Dictionary<int, Partition> Partitions { get; set; }
    }
    
    public class Partition
    {
    	[JsonProperty("partition")]
    	public int PartitionNo { get; set; }
    	[JsonProperty("next_offset")]
    	public int NextOffset { get; set; }
        // etc...
    }
