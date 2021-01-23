	public class MyXmlReader : XmlTextReader
	{
		public MyXmlReader(string filename)
			: base(filename)
		{
		}
		public override bool Read()
		{
			Console.WriteLine("Reading line {0}.", this.LineNumber);
			return base.Read();
		}
	}
