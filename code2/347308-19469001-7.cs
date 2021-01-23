	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using System.ServiceProcess;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	
	namespace Demos___Service_Plus_Console
	{
	    /// <summary>
	    /// When running in service mode.
	    /// </summary>
	    public partial class ServiceController : ServiceBase
	    {
	        public ServiceController()
	        {
	            InitializeComponent();
	        }
	
	        readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	
	        // Initialize payload.
	        private MainPayload myMain;
	
	        protected override void OnStart(string[] args)
	        {
	            myMain = new MainPayload(cancellationTokenSource); // Pass the token into the task.
	            Task.Run(() => myMain.Run());
	        }
	
	        protected override void OnStop()
	        {
	            cancellationTokenSource.Cancel();
	        }
	    }
	}
