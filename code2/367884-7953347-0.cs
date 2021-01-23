	public class Foo
	{
		public string Bar { get; set; }
		public int Baaz { get; set; }
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Foo>));
			MemoryStream ms = new MemoryStream(
				Encoding.UTF8.GetBytes("[{\"Bar\":\"Bar\",\"Baaz\":2}]"));
			var list = (List<Foo>)serializer.ReadObject(ms);
			Console.WriteLine(list.Count);
		}
	}
