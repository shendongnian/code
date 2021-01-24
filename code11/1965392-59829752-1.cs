	using System;
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Management.Automation;
	namespace PowerShellExecutionSample
	{
		class Program
		{
			static void Main(string[] args)
			{
				PowerShellExecutor t = new PowerShellExecutor();
				t.ExecuteSynchronously();
			}
		}
		/// <summary>
		/// Provides PowerShell script execution examples
		/// </summary>
		class PowerShellExecutor
		{
			public void ExecuteSynchronously()
			{
				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					//You mis-used the AddScript method. It needs the text of the script, not the script name
					string scriptText = File.ReadAllText(string.Format(@"{0}\PowerShellInner.ps1", Environment.CurrentDirectory));
					PowerShellInstance.AddScript(scriptText);
					Collection <PSObject> PSOutput = PowerShellInstance.Invoke();
					// loop through each output object item
					foreach (PSObject outputItem in PSOutput)
					{
						// if null object was dumped to the pipeline during the script then a null
						// object may be present here. check for null to prevent potential NRE.
						if (outputItem != null)
						{
							Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
						}
					}
				}
			}
		}
	}
	
