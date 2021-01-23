	public abstract class Foo : IFoo
	{
		IBar IFoo.GetBar()
		{
			return this.GetBar();
		}
				
		public Bar GetBar()
		{
			return this.GetBarInner();
		}
		protected abstract Bar GetBarInner();
	}
	
	public abstract class Bar : IBar { }
