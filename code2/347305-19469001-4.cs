	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	//using Gurock.SmartInspect; // Only used if we are logging using SmartInspect (see www.SmartInspect.com).
	namespace Demos___Service_Plus_Console
	{
	    /// <summary>
	    /// Main entry point for both console and Windows service.
	    /// </summary>
	    public class MainPayload
	    {
	        private readonly CancellationTokenSource _cancellationTokenSource;
	
	        /// <summary>
	        /// Constructor; do not block in this call; it is for setup only.
	        /// </summary>
	        public MainPayload(CancellationTokenSource cancellationTokenSource)
	        {
	            // Do not block in this call; it is for setup only.
	            _cancellationTokenSource = cancellationTokenSource;
	        }	
	        /// <summary>
	        /// Long running task here.
	        /// </summary>
	        public void Run()
	        {
	            while (_cancellationTokenSource.IsCancellationRequested == false)
	            {
	                //SiAuto.Main.LogMessage(".");
	                Console.WriteLine(".");
	
	                // This will break every N seconds, or immediately if on cancellation token.
	                _cancellationTokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
	            }
	            //SiAuto.Main.LogMessage("Exited Run().");
	            Console.WriteLine("Exited Run().");
	            Thread.Sleep(500); // If we remove this line, then we will miss the final few writes to the console.
	        }
	    }
	}
