	using System;
	using System.IO;
	using System.Xml;
	using System.Xml.Serialization;
	namespace ConsoleApplication1
	{
		[System.SerializableAttribute()]
		[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://someurl")]
		[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://someurl", IsNullable = false)]
		public partial class MyItem
		{
			[System.Xml.Serialization.XmlTextAttribute]
			public string Value { get; set; }
		}
		class Program
		{
			static void Main(string[] args)
			{
				var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<d:MyItem xmlns:d=\"http://someurl\" xmlns:m=\"http://someotherurl\">This is a string</d:MyItem>";
				var deserialized = Deserialize<MyItem>(xml);
				// Result:  deserialized.Value == "This is a string"
			}
			private static T Deserialize<T>(string xml) where T : new()
			{
				var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(new StringReader(xml));
			}
		}
	}
