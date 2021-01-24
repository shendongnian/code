    public class Asset
    {
    	public Asset()
    	{
    		VideoAsset = new HashSet<VideoAsset>();
    		TextAsset = new HashSet<TextAsset>();
    		ImageAsset = new HashSet<ImageAsset>();
    	}
    	
        public long Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
    
    	public ICollection<VideoAsset> VideoAsset { get; set; }
    	public ICollection<TextAsset> TextAsset { get; set; }
    	public ICollection<ImageAsset> ImageAsset { get; set; }
    }
    	
    
    public class VideoAsset 
    {
    	public int AssetId { get; set; }
    	public int width { get; set; }
    	public int height { get; set; }
    	public int length { get; set; }
    }
    
    public class TextAsset
    {
       public int AssetId { get; set; }
       public decimal fontSize { get; set; }
       public string fontColor { get; set; }
       public string fontName { get; set; }
    }
    
    public class ImageAsset
    {
    	public int AssetId { get; set; }
    	public int width { get; set; }
    	public int height { get; set; }
    }
