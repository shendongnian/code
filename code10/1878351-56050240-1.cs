	public static class Disposable
	{
		public static T Using<R, T>(Func<R> factory, Func<R, T> projection) where R : IDisposable
		{
			using (var r = factory())
			{
				return projection(r);
			}
		}
	}
