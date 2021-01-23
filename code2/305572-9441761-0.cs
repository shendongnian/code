    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using System.Windows.Forms;
    using System.IO;
    using System.Net.Mail;
    using System.Threading;
    using System.Management;
    
    namespace appMon
    {
    	public class appMon : ServiceBase
    	{
    		public const string serviceName = "appMon";		
    		public appMon()
    		{
    			InitializeComponent();			
    		}		
    		private void InitializeComponent()
    		{
    			this.ServiceName = serviceName;			
    		}		
    		/// <summary>
    		/// Clean up any resources being used.
    		/// </summary>
    		protected override void Dispose(bool disposing)
    		{
                // free instantiated object resources not handled by garbage collector
    			base.Dispose(disposing);
    		}
            public static string getCurrUser()
            {// gets the owner of explorer.exe/UI to determine current logged in user
                String User = String.Empty;
                String Domain = String.Empty;
                String OwnerSID = String.Empty;
                string processname = String.Empty;
                int PID = Process.GetProcessesByName("explorer")[0].Id;
                ObjectQuery sq = new ObjectQuery
                    ("Select * from Win32_Process Where ProcessID = '" + PID + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(sq);            
                foreach (ManagementObject oReturn in searcher.Get())
                {
                    string[] o = new String[2];
                    oReturn.InvokeMethod("GetOwner", (object[])o);
                    User = o[0];
                    System.IO.StreamWriter sr = new System.IO.StreamWriter(@"C:\user.txt");
                    sr.WriteLine("\\" + o[2] + "\\" + o[1] + "\\" + o[0]);
                    return User;
                }
                return User;
            }
            public static int readConfigFile()
            {
                int cputime = 5; // 5 min dflt
                try
                {
                    string readcfg;
                    readcfg = File.ReadAllText(@"c:\appMon\cpuUtilization.txt");
                    cputime = Convert.ToInt16(readcfg);
                    return cputime;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return cputime;  // 5 min dflt
                }
            }
            public static void logEvents(bool spoolerHang, bool appHang, string msg)
            {
            	try
                {
                	StreamWriter sw;
                    sw = File.AppendText(@"c:\appMon\appMonLog.txt");
                    sw.WriteLine(@"appMon spoolsv.exe event: " + "," + System.Environment.MachineName + "," + System.DateTime.Now + "," + msg);
                    sw.Close();
                }
                catch (Exception e)
                {
                	MessageBox.Show(e.ToString());
                }
            }
    		/// <summary>
    		/// Start this service.
    		/// </summary> 
    		protected override void OnStart(string[] args)
    		{// upon appMon load, a polling interval is set (in milliseconds 1000 ms = 1 s)
                System.Timers.Timer pollTimer = new System.Timers.Timer();
                pollTimer.Elapsed += new ElapsedEventHandler(pollTimer_Elapsed);
                pollTimer.Interval = 20000; // 20 sec
                pollTimer.Enabled = true;
            }
            public static void StartService(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    if (service.Status == ServiceControllerStatus.Stopped) // if service is not running...
                    {
                        service.Start(); // ...start the service
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            public static void StopService(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    if (service.Status == ServiceControllerStatus.Running) // if service is running...
                    {
                        service.Stop(); //...stop the service
                    }
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            public static void delFiles(string path)
            {
                string[] filePaths = Directory.GetFiles(path);
                foreach (string filePath in filePaths)
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception e)
                    {
                        // TODO:  !log to file instead!
                        MessageBox.Show("error deleting files: " + e.ToString());
                    }
                }
            }
            public static void getServiceInfo(string serviceName)
            {
                ServiceController service = new ServiceController(serviceName);
                ServiceController[] depServices = service.ServicesDependedOn;
                List<string> depServicesList = new List<string>();
                foreach (ServiceController sc in depServices)
                {
                    depServicesList.Add(sc.ServicesDependedOn.ToString());
                    logEvents(false, false, sc.ServicesDependedOn.ToString());
                }
    
            }
            void pollTimer_Elapsed(object sender, ElapsedEventArgs e)
            {// polling interval has elapsed            
                getServiceInfo("spooler");
                ServiceController serviceSpooler = new ServiceController("spooler");
                if (serviceSpooler.Status == ServiceControllerStatus.Stopped)
                {
                    logEvents(true, false, "Print Spooler is: " + serviceSpooler.Status.ToString());
                    serviceSpooler.Refresh();
                    serviceSpooler.Start();
                    logEvents(true, false, "Print Spooler is: " + serviceSpooler.Status.ToString());
                }            
                int cputime = readConfigFile();
                // get active processes (exe's, including services)
                Process[] processlist = Process.GetProcesses();
                // iterate through process list
                foreach (Process theprocess in processlist)
                {
                    // assign local variable to iterator - cures the foreach "gotcha"
                    Process p = theprocess;
                    if (p.ProcessName == "spoolsv") // "spoolsv" = windows name for spoolsv.exe aka "spooler"
                    {
                        if (p.TotalProcessorTime.Minutes > cputime) // has current spooler thread occupied >= cputime # mins of CPU time? 
                        {
                            logEvents(true, false, "spoolsv.exe CPU time (mins): " + p.TotalProcessorTime.Minutes.ToString());
                            p.Refresh();
                            StopService("spooler", 0);
                            StartService("spooler", 0);
                        }
                    }
                }
            }
    		/// <summary>
    		/// Stop this service.
    		/// </summary>
            /// 
    		protected override void OnStop()
    		{
    		}
    	}
    }
