    using System;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    [Cmdlet(VerbsCommon.Get, "Hello")]
    public class GetHelloCommand : Cmdlet
    {
    	protected override void EndProcessing()
    	{
    		WriteObject("Hello", true);
    	}
    }
    
    class MainClass
    {
    	public static void Main(string[] args)
    	{
    		PowerShell powerShell = PowerShell.Create();
    		var configuration = RunspaceConfiguration.Create();
    		configuration.Cmdlets.Append(new CmdletConfigurationEntry[] { new CmdletConfigurationEntry("Get-Hello", typeof(GetHelloCommand), "") });
    		powerShell.Runspace = RunspaceFactory.CreateRunspace(configuration);
    		powerShell.Runspace.Open();
    
    		powerShell.AddCommand("Get-Hello");
    		foreach (string str in powerShell.AddCommand("Out-String").Invoke<string>())
    			Console.WriteLine(str);
    	}
    }
