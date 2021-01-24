	public class Program
	{
		public static void Main(string[] args)
		{
			using var writer = new StringWriter();
			var serializer = new XmlSerializer(typeof(Player));
			serializer.Serialize(writer, new Player { Name = "", Age = 25 });
			Console.WriteLine(writer);
		}
	}
	public class Player
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
		[XmlAttribute("age")]
		public int Age { get; set; }
	}
The code above results in the name attribute in the format you desire (`name=""`). Let me know if this answer is sufficient for you.
