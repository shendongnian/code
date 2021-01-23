	class CommandArgs
	{
		public string Arg1 { get; set; }
		public virtual string ParsedValue
		{
			get
			{
				return "Arg1: " + Arg1;
			}
		}
	}
	class AdditionalCommandArgs : CommandArgs
	{
		public string Arg2 { get; set; }
		public string Arg3 { get; set; }
		public override string ParsedValue
		{
			get
			{
				return base.ParsedValue + "\r\n" +
				       "Arg2: " + Arg2 + "\r\n" +
				       "Arg3: " + Arg3;
			}
		}
	}
