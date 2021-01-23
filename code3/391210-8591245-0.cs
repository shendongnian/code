    void Main()
    {
    	var ser = new XmlSerializer(typeof(ParserSchedule));
    	var xml = @"<Schedule>
       <Month name=""March"">
    	 <Day name=""Monday"" />
       </Month>
       <Month name=""April"">
    	 <Day name=""Tuesday"" />
    	 <Day name=""Monday"" />
       </Month>
    </Schedule>";
    
    	using (var reader = new StringReader(xml))
    	{
    		var schedule = (ParserSchedule)ser.Deserialize(reader);
    		schedule.Dump(); // LINQPad method to dump object to debug
    	}
    }
    
    [XmlRoot("Schedule")]
    public class ParserSchedule
    {
       [XmlElement("Month")]
       public List<ParserMonth> Month{ get; set; } 
    }
    
    public class ParserMonth
    {
    	[XmlAttribute("name")]
    	public string Name{ get; set; }
    
    	[XmlElement("Day")]
    	public List<ParserDay> Day{ get; set; } 
    }
    
    public class ParserDay
    {
    	[XmlAttribute( "name" )]
    	public string Name{ get; set; }        
    }
    
    public class Day
    {
    	private Day() {} // new Day() should fail to compile
    }
