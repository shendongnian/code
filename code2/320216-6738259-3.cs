	public class ThingFactory
	{
		public virtual IThingSource CreateThingSource()
		{
			return new DefaultThingSource();
		}
	}
