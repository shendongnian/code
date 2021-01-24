c#
namespace SO56585341
{
	public interface IComputerInfoSource
	{
		string GetComputerName();
	}
}
There are a handful of ways to implement this to get the machine name of the **local computer**.  The simplest is to return the value of the [`Environment.MachineName` property](https://docs.microsoft.com/dotnet/api/system.environment.machinename)...
c#
namespace SO56585341
{
	public class EnvironmentClassComputerInfoSource : IComputerInfoSource
	{
		public string GetComputerName()
		{
			return System.Environment.MachineName;
		}
	}
}
You can also use the [`Environment.GetEnvironmentVariable()` method](https://docs.microsoft.com/dotnet/api/system.environment.getenvironmentvariable#System_Environment_GetEnvironmentVariable_System_String_) to retrieve the value of the `%ComputerName%` environment variable...
c#
namespace SO56585341
{
	public class EnvironmentVariableComputerInfoSource : IComputerInfoSource
	{
		public string GetComputerName()
		{
			return System.Environment.GetEnvironmentVariable("ComputerName");
		}
	}
}
You can [p/invoke](https://docs.microsoft.com/dotnet/standard/native-interop/pinvoke) the [`GetComputerName()` Windows API function](https://docs.microsoft.com/windows/win32/api/winbase/nf-winbase-getcomputernamew), which is what `Environment.MachineName` does [behind the scenes](https://referencesource.microsoft.com/#mscorlib/system/environment.cs,be0b5c103d248dce)...
c#
using System.Runtime.InteropServices;
using System.Text;
namespace SO56585341
{
	public class WinApiComputerInfoSource : IComputerInfoSource
	{
		private const int MAX_COMPUTERNAME_LENGTH = 15;
		
		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool GetComputerName(
			StringBuilder lpBuffer,
			ref int nSize
		);
		public string GetComputerName()
		{
			int maxCapacity = MAX_COMPUTERNAME_LENGTH + 1;
			StringBuilder nameBuilder = new StringBuilder(maxCapacity, maxCapacity);
			if (!GetComputerName(nameBuilder, ref maxCapacity))
			{
				// TODO: Error handling...
				throw new System.ComponentModel.Win32Exception();
			}
			return nameBuilder.ToString();
		}
	}
}
You can use WMI to retrieve the `Name` property of the singleton [`Win32_ComputerSystem` class](https://docs.microsoft.com/windows/win32/cimwin32prov/win32-computersystem).  You can do this by instantiating a [`ManagementClass`](https://docs.microsoft.com/dotnet/api/system.management.managementclass) instance for the `Win32_ComputerSystem` class and calling [`GetInstances()`](https://docs.microsoft.com/dotnet/api/system.management.managementclass.getinstances) on it to retrieve an array containing the sole instance...
c#
using System.Linq;
using System.Management;
namespace SO56585341
{
	public class WmiClassComputerInfoSource : IComputerInfoSource
	{
		public string GetComputerName()
		{
			using (ManagementClass computerSystemClass = new ManagementClass("Win32_ComputerSystem"))
			using (ManagementObjectCollection computerSystemCollection = computerSystemClass.GetInstances())
			using (ManagementObject computerSystem = computerSystemCollection.Cast<ManagementObject>().Single())
				return (string) computerSystem["Name"];
		}
	}
}
...or by creating a [`ManagementObjectSearcher`](https://docs.microsoft.com/dotnet/api/system.management.managementobjectsearcher) and using that to [`Get()`](https://docs.microsoft.com/dotnet/api/system.management.managementobjectsearcher.get) the lone `Win32_ComputerSystem` instance...
c#
using System.Linq;
using System.Management;
namespace SO56585341
{
	public class WmiSearcherComputerInfoSource : IComputerInfoSource
	{
		public string GetComputerName()
		{
			ObjectQuery computerSystemQuery = new SelectQuery("Win32_ComputerSystem");
			using (ManagementObjectSearcher computerSystemSearcher = new ManagementObjectSearcher(computerSystemQuery))
			using (ManagementObjectCollection computerSystemCollection = computerSystemSearcher.Get())
			using (ManagementObject computerSystem = computerSystemCollection.Cast<ManagementObject>().Single())
				return (string) computerSystem["Name"];
		}
	}
}
Finally, the value returned by all of the methods above seems to ultimately be stored in the registry, so if you don't mind relying on that implementation detail you can retrieve it from there directly...
c#
using Microsoft.Win32;
namespace SO56585341
{
	public class RegistryComputerInfoSource : IComputerInfoSource
	{
		public string GetComputerName()
		{
			// See also @"SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName\"
			// https://www.oreilly.com/library/view/windows-nt-workstation/9781565926134/10_chapter-07.html
			const string valueParentKeyPath = @"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName\";
			using (RegistryKey parentKey = Registry.LocalMachine.OpenSubKey(valueParentKeyPath, false))
				return (string) parentKey.GetValue("ComputerName");
		}
	}
}
---
As for getting the same value from a **remote computer** only the last three implementations above will work, though with minimal tweaking required.  First, just to complete this `IComputerInfoSource` example, let's create an `abstract` class to hold the remote machine name/address "parameter"...
c#
namespace SO56585341
{
	public abstract class RemoteComputerInfoSource : IComputerInfoSource
	{
		public string RemoteNameOrIp
		{
			get;
		}
		protected RemoteComputerInfoSource(string nameOrIp)
		{
			RemoteNameOrIp = nameOrIp ?? throw new System.ArgumentNullException(nameof(nameOrIp));	
		}
		public abstract string GetComputerName();
	}
}
Retrieving the `Win32_ComputerSystem` instance via a `ManagementClass` just becomes a matter of explicitly passing it a [`ManagementPath`](https://docs.microsoft.com/dotnet/api/system.management.managementpath) that also specifies the [`NamespacePath`](https://docs.microsoft.com/dotnet/api/system.management.managementpath.namespacepath) and [`Server`](https://docs.microsoft.com/dotnet/api/system.management.managementpath.server)...
c#
using System.Linq;
using System.Management;
namespace SO56585341
{
	public class RemoteWmiClassComputerInfoSource : RemoteComputerInfoSource
	{
		public RemoteWmiClassComputerInfoSource(string nameOrIp)
			: base(nameOrIp)
		{
		}
		public override string GetComputerName()
		{
			ManagementPath computerSystemPath = new ManagementPath() {
				ClassName = "Win32_ComputerSystem",
				NamespacePath = @"root\cimv2",
				Server = RemoteNameOrIp
			};
			using (ManagementClass computerSystemClass = new ManagementClass(computerSystemPath))
			using (ManagementObjectCollection computerSystemCollection = computerSystemClass.GetInstances())
			using (ManagementObject computerSystem = computerSystemCollection.Cast<ManagementObject>().Single())
				return (string) computerSystem["Name"];
		}
	}
}
A `ManagementObjectSearcher` can be used by passing a similar `ManagementPath` wrapped in a [`ManagementScope`](https://docs.microsoft.com/dotnet/api/system.management.managementscope)...
c#
using System.Linq;
using System.Management;
namespace SO56585341
{
	public class RemoteWmiSearcherComputerInfoSource : RemoteComputerInfoSource
	{
		public RemoteWmiSearcherComputerInfoSource(string nameOrIp)
			: base(nameOrIp)
		{
		}
		public override string GetComputerName()
		{
			ManagementScope computerSystemScope = new ManagementScope(
				new ManagementPath() {
					NamespacePath = @"root\cimv2",
					Server = RemoteNameOrIp
				}
			);
			ObjectQuery computerSystemQuery = new SelectQuery("Win32_ComputerSystem");
			using (ManagementObjectSearcher computerSystemSearcher = new ManagementObjectSearcher(computerSystemScope, computerSystemQuery))
			using (ManagementObjectCollection computerSystemCollection = computerSystemSearcher.Get())
			using (ManagementObject computerSystem = computerSystemCollection.Cast<ManagementObject>().Single())
				return (string) computerSystem["Name"];
		}
	}
}
Querying a remote registry just requires an additional call to [`OpenRemoteBaseKey()`](https://docs.microsoft.com/dotnet/api/microsoft.win32.registrykey.openremotebasekey) to get a handle to the root of the remote hive...
c#
using Microsoft.Win32;
namespace SO56585341
{
	public class RemoteRegistryComputerInfoSource : RemoteComputerInfoSource
	{
		public RemoteRegistryComputerInfoSource(string nameOrIp)
		: base(nameOrIp)
		{
		}
		public override string GetComputerName()
		{
			// See also @"SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName\"
			// https://www.oreilly.com/library/view/windows-nt-workstation/9781565926134/10_chapter-07.html
			const string valueParentKeyPath = @"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName\";
			using (RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, RemoteNameOrIp))
			using (RegistryKey parentKey = baseKey.OpenSubKey(valueParentKeyPath, false))
				return (string) parentKey.GetValue("ComputerName");
		}
	}
}
If you compile all of the above code into a project you can use the following `Program` class to test it...
c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace SO56585341
{
	public static class Program
	{
		private const string TestHost = "127.0.0.1";
		public static void Main()
		{
			// Get all non-abstract classes in the executing assembly that implement IComputerInfoSource
			IEnumerable<Type> computerInfoSourceTypes = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => type.IsClass && !type.IsAbstract && typeof(IComputerInfoSource).IsAssignableFrom(type));
			// For each constructor in each candidate class...
			foreach (Type computerInfoSourceType in computerInfoSourceTypes)
				foreach (ConstructorInfo constructor in computerInfoSourceType.GetConstructors())
				{
					ParameterInfo[] constructorParameters = constructor.GetParameters();
					object[] instanceParameters;
					// If the constructor takes no parameters...
					if (!constructorParameters.Any())
						instanceParameters = Array.Empty<object>();
					// ...or a single string parameter...
					else if (constructorParameters.Length == 1 && constructorParameters[0].ParameterType == typeof(string))
						instanceParameters = new object[1] { TestHost };
					// ...otherwise skip this constructor
					else
						continue;
					// Instantiate the class using the constructor parameters specified above
					IComputerInfoSource computerInfoSource = (IComputerInfoSource) constructor.Invoke(instanceParameters);
					string result;
					try
					{
						result = computerInfoSource.GetComputerName();
					}
					catch (Exception ex)
					{
						result = ex.ToString();
					}
					Console.WriteLine(
						"new {0}({1}).{2}(): \"{3}\"",
						computerInfoSourceType.Name,
						string.Join(
							", ",
							instanceParameters.Select(value => $"\"{value}\"")
						),
						nameof(IComputerInfoSource.GetComputerName),
						result
					);
				}
		}
	}
}
I found this code to work whether `TestHost` was set to a machine name, CNAME, or IP address.  Note that the `Remote*ComputerInfoSource` classes will fail if...
 - The appropriate service (`RemoteRegistry` or `Winmgmt`) is not running on the remote machine, or...
 - The appropriate firewall rule (e.g. `WMI-WINMGMT-In-TCP`) is not enabled on the remote machine, or...
 - The code is not run as a user with privileges to access the remote service.
---
As for PowerShell, one should be able to translate **any** of the above methods from C# and wrap them in a call to [`Invoke-Command`](https://docs.microsoft.com/powershell/module/microsoft.powershell.core/invoke-command) since that code will be executed local to the remote machine.  For example...
powershell
Invoke-Command -ComputerName $nameOrIp -ScriptBlock { $Env:COMPUTERNAME }
...or...
powershell
Invoke-Command -ComputerName $nameOrIp -ScriptBlock {
	Get-ItemProperty -Path 'HKLM:\SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName\' -Name 'ComputerName'
}
PowerShell also has the [`Get-WmiObject`](https://docs.microsoft.com/powershell/module/microsoft.powershell.management/get-wmiobject)...
powershell
Get-WmiObject   -Class 'Win32_ComputerSystem' -ComputerName $nameOrIp -Property 'Name'
...and [`Get-CimInstance`](https://docs.microsoft.com/powershell/module/cimcmdlets/get-ciminstance) cmdlets...
powershell
Get-CimInstance -Class 'Win32_ComputerSystem' -ComputerName $nameOrIp -Property 'Name'
...that make working with WMI much easier.  In general, **I would recommend using WMI** since it is pretty easy to use from C# and PowerShell for both local and remote queries, and it exists for exactly this purpose of retrieving system details without having to know about the underlying API calls or data representation.
Note that when using the `Invoke-Command` or `Get-CimObject` cmdlet that the `WinRM` service must be running on the remote machine and the appropriate firewall rule (e.g. `WINRM-HTTP-In-TCP-NoScope`) must be enabled.  Also, when passing an IP address to the `-ComputerName` parameter of either of those cmdlets that address must be matched by the value of [`WSMan:\localhost\Client\TrustedHosts`](https://docs.microsoft.com/powershell/module/microsoft.wsman.management/about/about_wsman_provider).  If you need to scan an entire network by IP address I tested and found that `TrustedHosts` accepts the `*` wildcard but not subnet masks, CIDR notation, or the `?` wildcard.
