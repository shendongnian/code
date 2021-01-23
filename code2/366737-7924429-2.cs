	public class SomeFoo : Foo
	{
		public new SomeBar GetBar()
		{
			return new SomeBar();
		}
		
		protected override Bar GetBarInner()
		{
			return this.GetBar();
		}
	}
	
	public class SomeBar : Bar { }
