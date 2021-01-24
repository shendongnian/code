	public class Link
	{
		[JsonProperty("href")] [Required] [MinLength(14)] [MaxLength(255)]
        [UriReferenceAttribute]
		public Uri Href { get; set; }
    }
