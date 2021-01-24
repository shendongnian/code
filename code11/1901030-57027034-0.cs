    public class Image
	{
		public string Source{ get; set; }
		public string Title{ get; set; }
	}
	public class ImageWithCaption : Image
	{
		public string CaptionDescription{ get; set; }
	}
	public class ImageWithSize : Image
	{
		public int PixelWidth{ get; set; }
		public int PixelHeight{ get; set; }
	}
