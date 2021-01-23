    /// <summary>
    /// An interface that the RealtimeRunner can use to notify a hosting service that it has failed
    /// </summary>
    public interface IFailureNotifier
    {
    	/// <summary>
    	/// Notify the owner of a failure
    	/// </summary>
    	void NotifyOfFailure();
    }
