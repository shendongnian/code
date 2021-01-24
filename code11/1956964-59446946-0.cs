    using System.Collections;
    using System.Diagnostics;
    using System.Timers;
    
    namespace NetWork.Plus
    {
        /// <summary>
        /// The NetworkMonitor class monitors network speed for each network adapter on the computer,
        /// using classes for Performance counter in .NET library.
        /// </summary>
        public class NetworkMonitor
    	{
    		private Timer timer;						// The timer event executes every second to refresh the values in adapters.
    		private ArrayList adapters;					// The list of adapters on the computer.
    		private ArrayList monitoredAdapters;		// The list of currently monitored adapters.
    
    		public NetworkMonitor()
    		{
    			this.adapters	=	new ArrayList();
    			this.monitoredAdapters	=	new ArrayList();
    			EnumerateNetworkAdapters();
    			
    			timer	=	new Timer(1000);
    			timer.Elapsed	+=	new ElapsedEventHandler(timer_Elapsed);
    		}
    
    		/// <summary>
    		/// Enumerates network adapters installed on the computer.
    		/// </summary>
    		private void EnumerateNetworkAdapters()
    		{
    			PerformanceCounterCategory category	=	new PerformanceCounterCategory("Network Interface");
    
    			foreach (string name in category.GetInstanceNames())
    			{
    				// This one exists on every computer.
    				if (name == "MS TCP Loopback interface")
    					continue;
    				// Create an instance of NetworkAdapter class, and create performance counters for it.
    				NetworkAdapter adapter	=	new NetworkAdapter(name);
    				adapter.dlCounter	=	new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
    				adapter.ulCounter	=	new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
    				this.adapters.Add(adapter);			// Add it to ArrayList adapter
    			}
    		}
    
    		private void timer_Elapsed(object sender, ElapsedEventArgs e)
    		{
    			foreach (NetworkAdapter adapter in this.monitoredAdapters)
    				adapter.refresh();
    		}
    
    		/// <summary>
    		/// Get instances of NetworkAdapter for installed adapters on this computer.
    		/// </summary>
    		public NetworkAdapter[] Adapters
    		{
    			get
    			{
    				return (NetworkAdapter[])this.adapters.ToArray(typeof(NetworkAdapter));
    			}
    		}
    
    		// Enable the timer and add all adapters to the monitoredAdapters list, unless the adapters list is empty.
    		public void StartMonitoring()
    		{
    			if (this.adapters.Count > 0)
    			{
    				foreach(NetworkAdapter adapter in this.adapters)
    					if (!this.monitoredAdapters.Contains(adapter))
    					{
    						this.monitoredAdapters.Add(adapter);
    						adapter.init();
    					}
    				
    				timer.Enabled	=	true;
    			}
    		}
    
    		// Enable the timer, and add the specified adapter to the monitoredAdapters list
    		public void StartMonitoring(NetworkAdapter adapter)
    		{
    			if (!this.monitoredAdapters.Contains(adapter))
    			{
    				this.monitoredAdapters.Add(adapter);
    				adapter.init();
    			}
    			timer.Enabled	=	true;
    		}
    
    		// Disable the timer, and clear the monitoredAdapters list.
    		public void StopMonitoring()
    		{
    			this.monitoredAdapters.Clear();
    			timer.Enabled	=	false;
    		}
    
    		// Remove the specified adapter from the monitoredAdapters list, and disable the timer if the monitoredAdapters list is empty.
    		public void StopMonitoring(NetworkAdapter adapter)
    		{
    			if (this.monitoredAdapters.Contains(adapter))
    				this.monitoredAdapters.Remove(adapter);	
    			if(this.monitoredAdapters.Count == 0)
    				timer.Enabled	=	false;
    		}
    	}
    }
    
    
    file NetworkAdapter.cs
    
    using System.Diagnostics;
    
    namespace NetWork.Plus
    {
        /// <summary>
        /// Represents a network adapter installed on the machine.
        /// Properties of this class can be used to obtain current network speed.
        /// </summary>
        public class NetworkAdapter
    	{
    		/// <summary>
    		/// Instances of this class are supposed to be created only in an NetworkMonitor.
    		/// </summary>
    		internal NetworkAdapter(string name)
    		{
    			this.name	=	name;
    		}
    
    		private long dlSpeed, ulSpeed;				// Download\Upload speed in bytes per second.
    		private long dlValue, ulValue;				// Download\Upload counter value in bytes.
    		private long dlValueOld, ulValueOld;		// Download\Upload counter value one second earlier, in bytes.
    
    		internal string name;								// The name of the adapter.
    		internal PerformanceCounter dlCounter, ulCounter;	// Performance counters to monitor download and upload speed.
    
    		/// <summary>
    		/// Preparations for monitoring.
    		/// </summary>
    		internal void init()
    		{
    			// Since dlValueOld and ulValueOld are used in method refresh() to calculate network speed, they must have be initialized.
    			this.dlValueOld	=	this.dlCounter.NextSample().RawValue;
    			this.ulValueOld	=	this.ulCounter.NextSample().RawValue;
    		}
    
    		/// <summary>
    		/// Obtain new sample from performance counters, and refresh the values saved in dlSpeed, ulSpeed, etc.
    		/// This method is supposed to be called only in NetworkMonitor, one time every second.
    		/// </summary>
    		internal void refresh()
    		{
    			this.dlValue	=	this.dlCounter.NextSample().RawValue;
    			this.ulValue	=	this.ulCounter.NextSample().RawValue;
    			
    			// Calculates download and upload speed.
    			this.dlSpeed	=	this.dlValue - this.dlValueOld;
    			this.ulSpeed	=	this.ulValue - this.ulValueOld;
    
    			this.dlValueOld	=	this.dlValue;
    			this.ulValueOld	=	this.ulValue;
    		}
    
    		/// <summary>
    		/// Overrides method to return the name of the adapter.
    		/// </summary>
    		/// <returns>The name of the adapter.</returns>
    		public override string ToString()
    		{
    			return this.name;
    		}
    
    		/// <summary>
    		/// The name of the network adapter.
    		/// </summary>
    		public string Name
    		{
    			get
    			{
    				return this.name;
    			}
    		}
    		/// <summary>
    		/// Current download speed in bytes per second.
    		/// </summary>
    		public long DownloadSpeed
    		{
    			get
    			{
    				return this.dlSpeed;
    			}
    		}
    		/// <summary>
    		/// Current upload speed in bytes per second.
    		/// </summary>
    		public long UploadSpeed
    		{
    			get
    			{
    				return this.ulSpeed;
    			}
    		}
    		/// <summary>
    		/// Current download speed in kbytes per second.
    		/// </summary>
    		public double DownloadSpeedKbps
    		{
    			get
    			{
    				return this.dlSpeed/1024.0;
    			}
    		}
    		/// <summary>
    		/// Current upload speed in kbytes per second.
    		/// </summary>
    		public double UploadSpeedKbps
    		{
    			get
    			{
    				return this.ulSpeed/1024.0;
    			}
    		}
    	}
    }
 
 
