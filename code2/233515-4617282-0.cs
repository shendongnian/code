    void Main()
    {
    	Testo testo = new Testo { First = "Phillip" };
    	var abc = Serialize<Testo>(testo);
    	abc.ToString().Dump();
    }
    
    public XDocument Serialize<T>(T obj)
    {
    	var builder = new System.Text.StringBuilder();
    	var settings = new XmlWriterSettings
    					   {
    						   Encoding = System.Text.Encoding.UTF8,
    						   Indent = true,
    						   IndentChars = ("\t"),
    						   OmitXmlDeclaration = false
    					   };
    
    	var serializer = new XmlSerializer(typeof(T));
    
    	using (var writer = XmlWriter.Create(builder, settings))
    	{
    		serializer.Serialize(writer, obj);
    	}
    	
    	var xml = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), XElement.Parse(builder.ToString()));
    
    	return xml;
    }
    
    public class Testo
    {
    	public string First;
    }
