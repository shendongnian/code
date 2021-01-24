    [XmlRoot(ElementName="file")]
	public class File {
		[XmlAttribute(AttributeName="resource")]
		public string Resource { get; set; }
		[XmlAttribute(AttributeName="size")]
		public string Size { get; set; }
		[XmlAttribute(AttributeName="checksum")]
		public string Checksum { get; set; }
	}
	[XmlRoot(ElementName="source")]
	public class Source {
		[XmlElement(ElementName="file")]
		public List<File> File { get; set; }
		[XmlAttribute(AttributeName="uri")]
		public string Uri { get; set; }
	}
	[XmlRoot(ElementName="manifest")]
	public class Manifest {
		[XmlElement(ElementName="source")]
		public Source Source { get; set; }
		[XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName="totalbytes")]
		public string Totalbytes { get; set; }
	}
One could call that lazy or cheating, but I don't see the point in writing code that can be generated for me in a second. You might not always get perfect results, but it's a good starting point. For example, it uses `string` for all attribute types. If you're expecting all numeric values you could replace those with `int` or `long`.
Now you can deserialize like this:
    var serializer = new XmlSerializer(typeof(Manifest), new XmlRootAttribute("manifest"));
    using (var stream = System.IO.File.OpenRead("test.xml"))
    {
        var deserialized = (Manifest)serializer.Deserialize(stream);
    }
Once you've got the data deserialized into *something*, the rest is much easier. You can either use the auto-generated models or map them to your own. 
