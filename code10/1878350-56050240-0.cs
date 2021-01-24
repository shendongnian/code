	public static class Disposables
	{
		public static T Using<R, T>(Func<R> factory, Func<R, T> projection) where R : IDisposable
		{
			using (var r = factory())
			{
				return projection(r);
			}
		}
	}
