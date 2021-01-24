    public class Asset
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
    }
    
    public class VideoAsset : Asset
    {
    	public int width { get; set; }
    	public int height { get; set; }
    	public int length { get; set; }
    }
    
    public class TextAsset : Asset
    {
       public decimal fontSize { get; set; }
       public string fontColor { get; set; }
       public string fontName { get; set; }
    }
    
    public class ImageAsset : Asset
    {
    	public int width { get; set; }
    	public int height { get; set; }
    }
