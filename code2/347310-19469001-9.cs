	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.ServiceProcess;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	//using Gurock.SmartInspect; // Only used if we are logging using SmartInspect (see www.SmartInspect.com).
	namespace Demos___Service_Plus_Console
	{
	    internal static class EntryPoint
	    {
	        // Run in console mode.
	        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
	        private static Task _task;
	
	        /// <summary>
	        /// The main entry point for the application.
	        /// </summary>
	        public static void Main(string[] args)
	        {
	            //SiAuto.Si.Connections = "pipe(reconnect=\"true\", reconnect.interval=\"10\", backlog.enabled=\"true\", backlog.flushon=\"debug\", backlog.keepopen=\"true\")";
	            //SiAuto.Si.Enabled = true;
	
	            if (Environment.UserInteractive)
	            {
	                // Make sure that we can write to the console.
	                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
	                Console.SetOut(standardOutput);
	
	                // If Ctrl-C is pressed in the console, we get to here.
	                Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
	                
	                MainPayload myMain = new MainPayload(_cancellationTokenSource); // Pass the token into the task.
	                _task = Task.Run(() => myMain.Run());
	
	                // Wait for the payload task to finish.
	                while (_cancellationTokenSource.IsCancellationRequested == false)
	                {
	                    // This will break every N seconds, or immediately if cancellation token is pinged.
	                    _cancellationTokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(10));
	                }
	            }
	            else
	            {
	                // Run as Windows Service.
	                var ServicesToRun = new ServiceBase[]
	                    {
	                        new ServiceController()
	                    };
	                ServiceBase.Run(ServicesToRun);
	            }
	
	            _task.Wait(TimeSpan.FromSeconds(10)); // Delay for console to write its final output.
	        }
	
	        static void myHandler(object sender, ConsoleCancelEventArgs args)
	        {
	            _cancellationTokenSource.Cancel();
	            //SiAuto.Main.LogMessage("CtrlC pressed.");
	            Console.WriteLine("CtrlC pressed.");
	        }
	    }
	}
