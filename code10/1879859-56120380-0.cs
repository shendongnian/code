	public interface IArbitraryQualifier
	{
		int Qualification
		{
			get;
		}
	}
	public class ArbitraryQualifier : IArbitraryQualifier
	{
		public const int MIN_QUALITY = 1;
		public int Qualification
		{
			get;
		}
	}
	public class Person
	{
		public IArbitraryQualifier ArbitraryQualifier2
		{
			get;
		}
		public bool AmIARealBoy
		{
			get
			{
				return this.ArbitraryQualifier2.Qualification >= ArbitraryQualifier.MIN_QUALITY;
			}
		}
	}
