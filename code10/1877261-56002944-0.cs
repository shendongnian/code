    public class RoutingTagsData
    {
    	public RoutingTagsData()
    	{
    		RoutingTags = new List<RoutingTag>();
    	}
    
        [Required]
        public IList<RoutingTag> RoutingTags { get; set; }
    }
