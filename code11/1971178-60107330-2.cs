c#
using System.Diagnostics;
using System.Management;
            Process myProcess = new Process();
            ProcessStartInfo remoteAdmin =
                        new ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\iisreset.exe /restart");
           
 
            var s = new SecureString();
            s.AppendChar('g');
            s.AppendChar('e');
            remoteAdmin.UserName = "xyz";
            remoteAdmin.Password = s;
            remoteAdmin.Domain = "localhost";
            myProcess.StartInfo = remoteAdmin;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.Start(); //---ERROR HERE
Method 2:
c#
            ConnectionOptions conn = new ConnectionOptions();
            conn.Impersonation = ImpersonationLevel.Impersonate;         
            conn.Username = @"Username";
            conn.Password = "";
            //ManagementScope theScope = new ManagementScope("\\\\" + txtServerName.Text + "\\root\\cimv2", conn);
            theScope.Connect();  //---ERROR HERE
2. I tried the below code to run powershell script from C# code but I need the script which takes remote server admin credentials and restart the IIS.
c#
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
        static void RunPsScriptMethod2()
        {
            StringBuilder sb = new StringBuilder();
            PowerShell psExec = PowerShell.Create();
            psExec.AddCommand(@"C:\Users\d92495j\Desktop\test.ps1");
            psExec.AddArgument(DateTime.Now);
            Collection<PSObject> results;
            Collection<ErrorRecord> errors;
            results = psExec.Invoke();
            errors = psExec.Streams.Error.ReadAll();
            if (errors.Count > 0)
            {
                foreach (ErrorRecord error in errors)
                {
                    sb.AppendLine(error.ToString());
                }
            }
            else
            {
                foreach (PSObject result in results)
                {
                    sb.AppendLine(result.ToString());
                }
            }
            Console.WriteLine(sb.ToString());
        }
