    using System;
    using System.ServiceProcess;
    using System.Threading;
    using System.Timers;
 
    namespace MyNamespace
    {
        public partial class Service1:  ServiceBase
        {
            Thread syncThread = null;
            System.Timers.Timer timer1;
            string filePath = @"C:\myfile.txt";
 
            public Service1()
            {
                InitializeComponent();             
            }
 
            protected override void OnStart(string[] args)
            {
                timer1 = new System.Timers.Timer();
                timer1.Interval = 60000; // 1 min
                timer1.Enabled = true;
                timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
                timer1.Start();
            }
            protected override void OnStop()
            {
                syncThread.Abort();
                timer1.Stop();
            }
            protected void timer1_Elapsed(object sender, ElapsedEventArgs e)
            {
                syncThread = new Thread(new ThreadStart(doThread));
                syncThread.Start();
            }
            protected void doThread()
            {
                // This will run for each timer interval that elapses
                // in its own separate thread, and each thread will
                // end when the processing in this function ends            
                // You'll need to develop a strategy for getting these 
                // into your app
                string username, domainName, password;
                // Log the domain service account in, here... 
                bool returnValue = LogonUser(userName, domainName, password,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);
                if (!returnValue) return;  // not logged in - report this
                using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                {
                    using (WindowsImpersonationContext impersonatedUser = newId.Impersonate()) 
                    {                 
                        bool fileAbsent = true;
                        string myFileText = String.Empty;
                        if (File.Exists(filePath))
                        {
                            fileAbsent = false;
                            FileStream fs = new FileStream(filePath, FileMode.Open);
                            StreamReader sr = new StreamReader(fs)
                            myFileText = sr.ReadToEnd();
                            sr.Close();
                            fs.Close();
                            File.Delete(filePath);
                        }
                        else
                        {
                            // report that file does not exist
                        }
                        if (myFileText != String.Empty)  // content found
                        {
                            // do processing here
                        }
                        else
                        {
                            //if (fileAbsent == false)
                            // report file was found, but empty
                        }
                    } 
                }    
            }
        }
    }
