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
				XmlSerializer xsSubmit = new XmlSerializer(t);
				xsSubmit.Serialize(writer, obj);
				xml = sww.ToString();
			}
		}
		return xml;
	}
