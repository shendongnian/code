	using System;
	using System.Security.Permissions;
	using Microsoft.Win32;
	[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify="HKEY_CURRENT_USER")]
	namespace sampleProgram
	{
		public class sampleClass
		{
			static void Main()
			{
				// open the registry key holding control panel international settings
				using (RegistryKey international = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true))
				{
					// get and display the current decimal character
					string original_sDecimal = international.GetValue("sDecimal").ToString();
					Console.WriteLine("original sDecimal='" + original_sDecimal + "'");
					Console.WriteLine("Press enter:");
					Console.ReadLine();
					// temporarily change the decimal character
					string alternate_sDecimal = "@";
					international.SetValue("sDecimal", alternate_sDecimal);
					Console.WriteLine("alternate sDecimal='" + international.GetValue("sDecimal").ToString() + "'");
					Console.WriteLine("Press enter:");
					Console.ReadLine();
					// put back the original decimal character
					international.SetValue("sDecimal", original_sDecimal);
					Console.WriteLine("restored original sDecimal='" + international.GetValue("sDecimal").ToString() + "'");
					Console.WriteLine("Press enter:");
					Console.ReadLine();
				}
			}
		}
	}
