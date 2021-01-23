    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    // contains base classes for webservice calls
    using System.ServiceModel; 
    
    // contains the DispatcherTimer class for callback timers
    using System.Windows.Threading; 
    
    namespace ASPSandcastleWPFClient
    {
    	/// <summary>
    	/// DispatcherTimer usage info thanks to:
    	/// 
    	/// Wildermuth, Shawn, "Build More Responsive Apps With The Dispatcher", MSDN Magazine, October 2007
    	/// Original URL: http://msdn.microsoft.com/en-us/magazine/cc163328.aspx
    	/// Archived at http://www.webcitation.org/605qBiUEC on July 11, 2011.
    	/// 
    	/// this class is not set up to handle multiple outstanding calls on the same async call;
    	/// if you wish to do that, there would need to be some sort of handling for multiple
    	/// outstanding calls designed into the helper.
    	/// </summary>
    	public class AsyncCallHelper
    	{
    		#region Static Defaults
    		private static TimeSpan myDefaultTimeout;
    		/// <summary>
    		/// default timeout for all instances of the helper; should different timeouts
    		/// be required, a member should be created that can override this setting.
    		/// 
    		/// if this is set to null or a value less than zero, the timout will be set 
    		/// to TimeSpan.Zero, and the helper will not provide timeout services to the 
    		/// async call.
    		/// </summary>
    		public static TimeSpan DefaultTimeout
    		{
    			get
    			{
    				return myDefaultTimeout;
    			}
    			set
    			{
    				if ((value == null) || (value < TimeSpan.Zero))
    					myDefaultTimeout = TimeSpan.Zero;
    				else
    					myDefaultTimeout = value;
    			}
    		}
    		#endregion
    
    		/// <summary>
    		/// creates an instance of the helper to assist in timing out on an async call
    		/// </summary>
    		/// <param name="AsyncCall">the call which is represented by this instance. may not be null.</param>
    		/// <param name="FailureAction">an action to take, if any, upon the failure of the call. may be null.</param>
    		public AsyncCallHelper(Action AsyncCall, Action FailureAction)
    		{
    			myAsyncCall = AsyncCall;
    			myFailureAction = FailureAction;
    			
    			myTimer = new DispatcherTimer();
    			myTimer.Interval = DefaultTimeout;
    			myTimer.Tick += new EventHandler(myTimer_Tick);
    		}
    
    		/// <summary>
    		/// Make the call
    		/// </summary>
    		public void BeginAsyncCall()
    		{
    			myAsyncCall();
    
    			if (DefaultTimeout > TimeSpan.Zero)
    			{
    				myTimer.Interval = DefaultTimeout;
    				myTimer.Start();
    			}
    		}
    
    		/// <summary>
    		/// The client should call this upon receiving a response from the
    		/// async call.  According to the reference given above, it seems that 
    		/// the WPF will only be calling this on the same thread as the UI, 
    		/// so there should be no real synchronization issues here.  
    		/// 
    		/// In a true multi-threading situation, it would be necessary to use
    		/// some sort of thread synchronization, such as lock() statements
    		/// or a Mutex in order to prevent the condition where the call completes
    		/// successfully, but the timer fires prior to calling "CallComplete"
    		/// thus firing the FailureAction after the success of the call.
    		/// </summary>
    		public void CallComplete()
    		{
    			if ((DefaultTimeout != TimeSpan.Zero) && myTimer.IsEnabled)
    				myTimer.Stop();
    		}
    
    		private void myTimer_Tick(object sender, EventArgs e)
    		{
    			CallComplete();
    
    			if (myFailureAction != null)
    				myFailureAction();
    		}
    
    		/// <summary>
    		/// WPF-friendly timer for use in aborting "Async" Webservice calls
    		/// </summary>
    		private DispatcherTimer myTimer;
    
    		/// <summary>
    		/// The call to be made
    		/// </summary>
    		private Action myAsyncCall;
    
    		/// <summary>
    		/// What action the helper should take upon a failure
    		/// </summary>
    		private Action myFailureAction;
    	}
    
    }
