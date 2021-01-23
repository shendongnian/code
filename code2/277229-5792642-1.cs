    /// <summary>
    /// Proxy used to get a call from the child appdomain into this appdomain
    /// </summary>
    public sealed class FailureNotifier: MarshalByRefObject, IFailureNotifier
    {
    	private static readonly Logger Log = LogManager.GetCurrentClassLogger();
    
    	#region IFailureNotifier Members
    
    	public void NotifyOfFailure()
    	{
    		Log.Warn("Received NotifyOfFailure in RTPService");
    
    		// Must call from threadpool thread, because the PerformMessageAction unloads the appdomain that called us, the thread would get aborted at the unload call if we called it directly
    		Task.Factory.StartNew(() => {Processor.RtpProcessor.PerformMessageAction(ProcessorMessagingActions.Restart, null);});
    	}
    
    	#endregion
    }
