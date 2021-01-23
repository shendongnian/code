    using System;
    using System.Management.Automation;
    using log4net;
    
    // load log4net configuration from app.config
    [assembly:log4net.Config.XmlConfigurator]
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static PowerShell _ps;
            private static ILog Log = log4net.LogManager.GetLogger(typeof (Program));
    
            static void Main(string[] args)
            {
                string script = "write-debug 'this is a debug string' -debug";
    
                for (int packageId = 1; packageId <= 5; ++packageId)
                {
                    using (_ps = PowerShell.Create())
                    {
                        _ps.Commands.AddScript(script);
                        _ps.Streams.Debug.DataAdded += WriteDebugLog;
    
                        // set the PackageID global log4net property 
                        log4net.GlobalContext.Properties["PackageID"] = packageId;
                        
                        // sync invoke your pipeline
                        _ps.Invoke();
                        
                        // clear the PackageID global log4net property 
                        log4net.GlobalContext.Properties["PackageID"] = null;
                    }
                }        
            }
    
            private static void WriteDebugLog(object sender, DataAddedEventArgs e)
            {
                // get the debug record and log the message
                var record = _ps.Streams.Debug[e.Index];
                Log.Debug(record.Message);            
            }
        }
    }
