using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
private static Runspace OpenExchangeManagementRunspace(
    string url,
    AuthenticationMechanism authenticationMechanism = AuthenticationMechanism.Kerberos,
    string userName = null,
    string password = null)
{
    Runspace runspace = null;
    WSManConnectionInfo shellConnection = null;
    PSCredential shellCred = null;
    // Username and password is optional when using Kerberos authentication
    if (!string.IsNullOrWhiteSpace(userName) &&
        !string.IsNullOrWhiteSpace(password))
    {
        var securePassword = ConvertToSecureString(password);
        shellCred = new PSCredential(userName, securePassword);
    }
    shellConnection = new WSManConnectionInfo(new Uri(url), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", shellCred);
    shellConnection.AuthenticationMechanism = authenticationMechanism;
    // This will take some time
    runspace = RunspaceFactory.CreateRunspace(shellConnection);
    runspace.Open();
    return runspace;
}
// USAGE:
// URL for Office365:
//     https://outlook.office365.com/powershell-liveid/
//
// URL for on-premises Exchange server:
//     http://hostname/powershell?serializationLevel=Full;clientApplication=MyAppName
//
using (Runspace remoteRunspace = OpenExchangeManagementRunspace("https://example.com/powershell?serializationLevel=Full;clientApplication=MyExampleAppName"))
using (PowerShell shell = PowerShell.Create())
{
    shell.Runspace = remoteRunspace;
    // Run some commands:
    shell
        .AddCommand("Get-Mailbox")
        .AddParameter("Identity", "example@example.com")
        .Invoke();
}
