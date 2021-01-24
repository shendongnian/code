    public class Asset
    {
    	public Asset()
    	{
    		Metadata = new HashSet<AssetMetadata>();
    	}
    	
        public long Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
    
    	public ICollection<AssetMetadata> Metadata { get; set; }
    }
    
    public class AssetMetadata 
    {
    	public int AssetId { get; set; }
    	public int width { get; set; }
    	public int height { get; set; }
    	public int length { get; set; }
    	public decimal fontSize { get; set; }
    	public string fontColor { get; set; }
    	public string fontName { get; set; }
    }
