    namespace Wmi
    {
        using System;
        using System.Security;
        using System.Threading;
        using System.Management;
        /// <summary>Performs various WMI operations.</summary>
        public static class WmiOperations
        {
            /// <summary>Runs some command.</summary>
            /// <param name="command">The command to run.</param>
            /// <param name="commandline">The command arguments (default=none).</param>
            /// <param name="machine">The machine on which to run the command (default=current one).</param>
            /// <param name="domain">Domain for 'username' (default=current domain).</param>
            /// <param name="username">The user that runs the command (default=current user).</param>
            /// <param name="password">User's password (default=current user password)</param>
            /// <param name="securePassword">Crypted user's password (default=current user password)</param>        
            /// <param name="wait">Command's timeout expiration.</param>
            /// <remarks>'wait==0' => Doesn't wait for process.</remarks>
            /// <remarks>'wait==+Inf' => Wait for process to end.</remarks>
            /// <remarks>'wait==]0;+Inf[' => Wait at most 'wait' seconds and then times-out.</remarks>
            /// TODO: ?? Replace 'wait' parameter with some cancel callback ??
            public static int Run(string command, 
                                  string commandline = null, 
                                  string machine = null,
                                  string domain = null,
                                  string username = null,
                                  string password = null,
                                  SecureString securePassword = null,
                                  double wait = double.PositiveInfinity)
            {
                // Checking parameters
                if (String.IsNullOrWhiteSpace(command)) { throw new ArgumentException("Undefined command"); }
                if ((securePassword != null) && (password != null)) { throw new ArgumentException("Cannot indicate both crypted and non cryped password."); }
                if (((password == null) && (securePassword == null) && (username != null)) ||
                    (((password != null) || (securePassword != null)) && (username == null)))
                {
                    throw new ArgumentException("Must indicate for both a password and a username.");
                }
                if (double.IsNaN(wait) || (wait < 0.0)) { throw new ArgumentException("wait range is [0;+Inf]"); }
                // Default values
                if (commandline == null) { commandline = ""; }
                if (machine == null) { machine = Environment.GetEnvironmentVariable("COMPUTERNAME"); }
                if (domain == null) { domain = Environment.GetEnvironmentVariable("USERDOMAIN"); }           
                if (username == null) { username = Environment.GetEnvironmentVariable("USERNAME"); }
            
                // Process survey
                var processId = new[] { (uint)0 };
                var exitCode = 0;
                var eventArrived = false;
                var mre = new ManualResetEvent(false);            
                var arguments = (command + " " + commandline).Trim();
                var w = (ManagementEventWatcher)null;
                var scope = (ManagementScope)null;
                var doWait = (wait > 0.0);
                var doWaitForever = (double.IsPositiveInfinity(wait));
                try
                {
                    // Connecting to WMI scope
                    var span = TimeSpan.FromSeconds(0); // TODO: ?? relate to 'wait' or check cancel ??
                    scope = connectToWmiScope(machine, domain, username, password, securePassword, span);
                    // Begin waiting process to stop
                    if (doWait)
                    {
                        Func<uint> getProcessId = () => processId[0];
                        Action<int> setExitCode = (code) => exitCode = code;
                        var q = new WqlEventQuery("Win32_ProcessStopTrace");
                        w = new ManagementEventWatcher(scope, q);
                        w.EventArrived += (sender, e) =>
                        {
                            var hasStoppedId = (uint)e.NewEvent.Properties["ProcessId"].Value;
                            if (hasStoppedId != getProcessId()) { return; }
                            setExitCode((int)(uint)e.NewEvent.Properties["ExitStatus"].Value);
                            mre.Set();
                        };
                        w.Start();
                    }
                    // Create the process
                    processId[0] = createProcess(scope, arguments);
                
                    // Are we done yet ?
                    if (!doWait) { return 0; }
                    // Wait for process
                    if (doWaitForever)
                    {
                        eventArrived = mre.WaitOne();
                    }
                    else
                    {
                        var waitMs = (int)(1000.0 * wait);
                        eventArrived = mre.WaitOne(waitMs, false);    
                    }                
                    w.Stop();                 
                    if (!eventArrived)
                    {
                        throw new TimeoutException();                    
                    }
            
                    // Result
                    return exitCode;               
                }
                catch (Exception ex)
                {
                    var msg = string.Format("Command execution failed:\n" +
                                            "  > Machine =  {0}\n" +
                                            "  > Command =  {1}\n" +
                                            "  > CommandLine = {2}\n" +
                                            "  > Domain = {3}\n" +
                                            "  > Username = {4}\n" +
                                            "  > Password = {5}\n" +
                                            "  > SecurePassword = {6}\n" +
                                            "  > Wait = {7}",
                                            machine, command, commandline, domain, username, password ?? "", (securePassword == null) ? "" : securePassword.ToString(), wait);
                    if (ex is TimeoutException)
                    {
                        bool found;
                        if ((scope != null) && (processId[0] != 0)) { tryKillProcess(scope, processId[0], out found);}
                    }
                
                    throw new Exception(msg, ex);
                }
                finally
                {
                    if (w != null) { w.Dispose(); }
                }
            }
            private static ManagementScope connectToWmiScope(string machine, string domain, string username, string password, SecureString securePassword, TimeSpan span)
            {
                // Full username
                if (!String.IsNullOrEmpty(domain)) { username = String.Format(@"{0}\{1}", domain, username); }
                var connectionOptions = new ConnectionOptions
                {
                    Impersonation = ImpersonationLevel.Impersonate,
                    EnablePrivileges = true,
                    Username = ((password == null) && (securePassword == null)) ? null : username,
                    Password = password,
                    SecurePassword = securePassword,
                    Timeout = span,
                };
                var managementScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", machine), connectionOptions);
                try
                {
                    managementScope.Connect();
                }
                catch (Exception ex)
                {
                    var msg = String.Format("Connecting to '{0}' as {1} failed", machine, username);
                    throw new Exception(msg, ex);
                }
                return managementScope;
            }
            private static uint createProcess(ManagementScope scope, string arguments)
            {
                var objectGetOptions = new ObjectGetOptions();
                var managementPath = new ManagementPath("Win32_Process");
                using (var processClass = new ManagementClass(scope, managementPath, objectGetOptions))
                {
                    using (var inParams = processClass.GetMethodParameters("Create"))
                    {
                        inParams["CommandLine"] = arguments;
                        using (var outParams = processClass.InvokeMethod("Create", inParams, null))
                        {
                            var err = (uint) outParams["returnValue"];
                            if (err != 0)
                            {
                                var info = "see http://msdn.microsoft.com/en-us/library/windows/desktop/aa389388(v=vs.85).aspx";
                                switch (err)
                                {
                                    case 2: info = "Access Denied"; break;
                                    case 3: info = "Insufficient Privilege"; break;
                                    case 8: info = "Unknown failure"; break;
                                    case 9: info = "Path Not Found"; break;
                                    case 21: info = "Invalid Parameter"; break;
                                }
                                var msg = "Failed to create process, error = " + outParams["returnValue"] + " (" + info + ")";
                                throw new Exception(msg);
                            }
                            return (uint)outParams["processId"];
                        }
                    }
                }            
            }
            private static bool tryKillProcess(ManagementScope scope, uint processId, out bool found)
            {
                found = false;
                var stopped = true;
                var sq = new SelectQuery("Select * from Win32_Process Where ProcessId = " + processId);
                using (var searcher = new ManagementObjectSearcher(scope, sq))
                {
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        var errcode = (uint)queryObj.InvokeMethod("Terminate", null);
                    queryObj.Dispose();
                        found = true;
                        stopped &= (errcode == 0);                    
                    }
                }
                return (found && stopped);
            }
        }
    }
