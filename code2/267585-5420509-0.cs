	public abstract class MyAbstract
	{
		protected readonly string SomeField;
		public MyAbstract()
		{
			SomeField = "Some";
		}
	}
	public abstract class MyInheited
	{
		public MyInheited(): base()
		{
		}
	}
