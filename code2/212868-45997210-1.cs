    // override StringWriter
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
	private string GenerateXmlResponse(Object obj)
	{    
		Type t = obj.GetType();
		var xml = "";
		using (StringWriter sww = new Utf8StringWriter())
		{
			using (XmlWriter writer = XmlWriter.Create(sww))
			{
				var ns = new XmlSerializerNamespaces();
                // add empty namespace
                ns.Add("", "");
                XmlSerializer xsSubmit = new XmlSerializer(t);
                xsSubmit.Serialize(writer, obj, ns);
                xml = sww.ToString(); // Your XML
			}
		}
		return xml;
	}
