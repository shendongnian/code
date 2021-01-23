    void Main()
    {
    	var foo = new Foo
    	{
    		Name = "name",
    		fooType = "type",
    		BarObject = new Bar { BarString = "bar"}
    	};
    
    	var s = new XmlSerializer(typeof(Foo));
    	using (var writer = new StringWriter())
    	{
    		s.Serialize(writer, foo);
    		writer.ToString().Dump();
    	}
    }
    
    
    public class Foo {
    
    	[XmlAttribute("Type")]
    	public string fooType;
    
    	[XmlElement("Name")]
    	public string Name;
    
    	[XmlElement("Message")]
    	public Bar BarObject;
    }
    
    public class Bar {
    
    	[XmlText]
    	public string BarString;
    }
