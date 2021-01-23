    Dim Locator
    Set Locator = CreateObject("WbemScripting.SWbemLocator")
    Dim objs
    Set Service = Locator.ConnectServer(".", "root\cimv2")
    Set objs = Service.ExecQuery("Select * From Win32_PerfRawData_MSMQ_MSMQQueue")
    For Each object In objs
        WScript.Echo "Name: " & object.Name
    Next 
---
    using System.Management;
    namespace TestMSMQStuff
    {
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    
    			System.Management.SelectQuery q = new SelectQuery("Select * From Win32_PerfRawData_MSMQ_MSMQQueue");
    			ManagementObjectSearcher s = new ManagementObjectSearcher(q);
    			foreach (var r in s.Get())
    			{
    				Console.WriteLine(r.Properties["Name"].Value);
    			}
    		}
    	}
    }
