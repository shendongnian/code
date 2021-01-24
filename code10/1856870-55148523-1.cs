	/// <summary>
	/// Implements the Dispose pattern for the AmazonWebServiceClient
	/// </summary>
	/// <param name="disposing">Whether this object is being disposed via a call to Dispose
	/// or garbage collected.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing && logger != null)
			{
				logger.Flush();
				logger = null;
			}
			this.disposed = true;
		}
	}
