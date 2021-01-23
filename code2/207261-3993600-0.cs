	public class SomeClass : IDisposable
	{
		private Boolean mDisposed;
		private readonly MemoryStream mStream = new MemoryStream();	// Could be any class that implements IDisposable
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected void Dispose(Boolean disposing) {
			if (disposing & !mDisposed) {
				mStream.Dispose();	// Could and should call Dispose
				mDisposed = true;
			}
			return;
		}
	}
