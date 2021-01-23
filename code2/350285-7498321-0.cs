	public class MetaCode
	{
		private IList<Fields> fields;
		private IList<Properties> properties;
		private IList<Methods> methods;
		public IList<Fields> Fields
		{
			get { return this.fields; }
		}
		public IList<Properties> Properties
		{
			get { return this.properties; }
		}
		public IList<Methods> Methods
		{
			get { return this.methods; }
		}
		// etc...
	}
	public interface ISourceReader
	{
		MetaCode ReadCode(string sourceCode);
	}
	public interface ISourceWriter
	{
		string WriteCode(MetaCode metaCode);
	}
