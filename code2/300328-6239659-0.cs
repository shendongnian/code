	public class Param
	{
		public string A { get; private set; }
		public string B { get; private set; }
		public string C { get; private set; }
		
		public class Builder
		{
			private string a;
			private string b;
			private string c;
			
			public Builder WithA(string value)
			{
				a = value;
				return this;
			}
			
			public Builder WithB(string value)
			{
				b = value;
				return this;
			}
			
			public Builder WithC(string value)
			{
				c = value;
				return this;
			}
			
			public Param Build()
			{
				return new Param { A = a, B = b, C = c };
			}
		}
		
		
		DoSomeAction(new Param.Builder()
			.WithA("a")
			.WithB("b")
			.WithC("c")
			.Build());
		
		
