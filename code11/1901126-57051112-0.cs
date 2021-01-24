    public class Rule : MustInitialize<IParameters>, IRule
    {
		public Rule()
			: base (new Parameters())
		{
			// Assuming Parameters is a class that implements the IParameters interface
		}
    }
