	public class XXX
	{
		private XXX()
		{
		}
		
		private void DoMyWeirdThingsAsynchronously()
		{
			....
		}
		public static XXX PerformSomethingStrange()
		{
			XXX result = new XXX();
			result.DoMyWeirdThingsAsynchronously();
			return result;
		}
	}
