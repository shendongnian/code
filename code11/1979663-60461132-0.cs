	public class Cage
	{
		public Cage(Kitten kitten)
		{
			this.Kitten = kitten;
		}
	
		public Kitten Kitten { get; set; }
	
		public string EchoKittenProperty(Func<Kitten, string> projection)
		{
			return projection(this.Kitten);
		}
	}
