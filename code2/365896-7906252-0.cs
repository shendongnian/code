    public class Pagination
    {
        [XmlElement("page")]
        public List<ResultsPage> Pages { get; set; }
        [XmlElement("total-pages")]
        public int TotalPages { get; set; }
    }
    
    public class ResultsPage
    {
    	[XmlAttribute("position")]
    	public string Position;
    	
    	[XmlText]
    	public string Text;
    }
