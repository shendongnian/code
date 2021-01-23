    void Main()
    {
    	var g = new Group();
    	g.SubGroups.Add(new SubGroup {Name = "aaa"});
    
    	var ser = new XmlSerializer(typeof(Group[]), new XmlRootAttribute("Groups"));
    	using (var w = new StringWriter())
    	{
    		ser.Serialize(w, new Group[] {g});
    		w.ToString().Dump();
    	}
    }
    
    public class Group
    {
    	[XmlElement("SubGroup")]
    	public List<SubGroup> SubGroups = new List<SubGroup>();
    }
    
    public class SubGroup
    {
    	public string Name;
    }
