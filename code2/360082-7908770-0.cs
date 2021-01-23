    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.ServiceProcess;
    
    namespace v7quickbar
    {
    	class NotifiableServiceController : INotifyPropertyChanged
    	{
    
    		private ServiceController m_oServiceController = null;
    		private System.Timers.Timer m_oServiceCheckTimer = new System.Timers.Timer();
    
    		public ServiceControllerStatus Status { get { return this.m_oServiceController.Status; } }
    
    		public string DisplayName { get { return this.m_oServiceController.DisplayName; } }
    
    		public string ServiceName { get { return this.m_oServiceController.ServiceName; } }
    
    		public bool CanStop { get { return this.m_oServiceController.CanStop; } }
    
    		public NotifiableServiceController(ServiceController oService)
    		{
    			CreateObject(oService, TimeSpan.FromSeconds(.5));
    		}
    
    		public NotifiableServiceController(ServiceController oService, TimeSpan oInterval)
    		{
    			CreateObject(oService, oInterval);
    		}
    
    		private void CreateObject(ServiceController oService, TimeSpan oInterval)
    		{
    			m_oServiceController = oService;
    			m_oServiceCheckTimer.Interval = oInterval.TotalMilliseconds;
    
    			m_oServiceCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(m_oServiceCheckTimer_Elapsed);
    			m_oServiceCheckTimer.Start();
    		}
    
    		public void Start()
    		{
    			try
    			{
    				this.m_oServiceController.Start();
    				this.m_oServiceController.WaitForStatus(ServiceControllerStatus.Running);
    			}
    			catch (Exception)
    			{
    			}
    		}
    
    		public void Stop()
    		{
    			try
    			{
    				this.m_oServiceController.Stop();
    				this.m_oServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
    			}
    			catch (Exception)
    			{
    			}
    		}
    
    		public void Restart()
    		{
    			try
    			{
    				if (m_oServiceController.CanStop && (m_oServiceController.Status == ServiceControllerStatus.Running || m_oServiceController.Status == ServiceControllerStatus.Paused))
    				{
    					this.Stop();
    					this.m_oServiceController.WaitForStatus(ServiceControllerStatus.Stopped);
    				}
    
    				if (m_oServiceController.Status == ServiceControllerStatus.Stopped)
    				{
    					this.Start();
    					this.m_oServiceController.WaitForStatus(ServiceControllerStatus.Running);
    				}
    			}
    			catch (Exception)
    			{
    			}
    		}
    
    		void m_oServiceCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    		{
    			ServiceControllerStatus oCurrentStatus = m_oServiceController.Status;
    			m_oServiceController.Refresh();
    
    			if (oCurrentStatus != m_oServiceController.Status)
    			{
    				PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Status"));
    			}
    
    		}
    
    		public static IEnumerable<NotifiableServiceController> GetServices()
    		{
    			List<NotifiableServiceController> oaServices = new List<NotifiableServiceController>();
    			foreach (ServiceController sc in ServiceController.GetServices())
    			{
    				oaServices.Add(new NotifiableServiceController(sc));
    			}
    
    			return oaServices;
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
    }
