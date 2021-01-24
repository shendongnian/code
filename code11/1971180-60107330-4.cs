c#
using System.Diagnostics;
using System.Management;
using System.IO;
using System.Security;
Process myProcess = new Process();
ProcessStartInfo remoteAdmin =
            new ProcessStartInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "iisreset.exe"));
            remoteAdmin.Arguments = "/restart";
myProcess.StartInfo.Verb = "runas";
var s = new SecureString();
//s.AppendChar('g');
 Console.WriteLine("Enter username:");          
 string userName = Console.ReadLine();
 Console.WriteLine(Environment.NewLine);
 Console.WriteLine("Enter password:");
 string password = Console.ReadLine();
Console.WriteLine(Environment.NewLine);
var securePasswordString = new SecureString();
// Use ToCharArray to convert string to array.
char[] array = password.ToCharArray();
// Loop through array.
for (int i = 0; i < array.Length; i++)
{
    // Get character from the array.
    securePasswordString.AppendChar(array[i]);            
}
remoteAdmin.UserName = userName;
remoteAdmin.Password = securePasswordString;
remoteAdmin.Domain = "localhost";
myProcess.StartInfo = remoteAdmin;
myProcess.StartInfo.UseShellExecute = false;
myProcess.StartInfo.RedirectStandardOutput = true;
myProcess.Start(); //---ERROR HERE
if (!myProcess.Start())
{
    // That didn't work
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Process did not start!!!");
}
myProcess.WaitForExit();
var processExitCode = myProcess.ExitCode;
if (processExitCode == 0)
{
   Console.WriteLine("The operation completed successfully.");
}
if (processExitCode != 0)
{
   // That didn't work
   if (processExitCode == 5)
      {
         Console.WriteLine(Environment.NewLine);
         Console.WriteLine("Access Denied");
      }
}
Console.ReadKey();
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
