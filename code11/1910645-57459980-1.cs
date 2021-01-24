        class Program
		{
			private static string _xml = @"c:\temp\myxml.xml";
			static void Main(string[] args)
			{
				var personal = Deserialize<Personal>(_xml);
				var contact = Deserialize<Contact>(_xml);
			}
			public static T Deserialize<T>(string file)
			{
				var serializer = new XmlSerializer(typeof(T));
				using (var xmlReader = XmlReader.Create(file))            
					return (T)serializer.Deserialize(xmlReader);            
			}
		}   
