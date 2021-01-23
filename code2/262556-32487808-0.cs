    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.Wmi;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.Win32;
    
    namespace SqlServerEnumerator
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Dictionary<string, Func<List<string>>> methods = new Dictionary<string, Func<List<string>>>
    			{
    				{"CallSqlBrowser", GetLocalSqlServerInstancesByCallingSqlBrowser},
    				{"CallSqlWmi32", GetLocalSqlServerInstancesByCallingSqlWmi32},
    				{"CallSqlWmi64", GetLocalSqlServerInstancesByCallingSqlWmi64},
    				{"ReadRegInstalledInstances", GetLocalSqlServerInstancesByReadingRegInstalledInstances},
    				{"ReadRegInstanceNames", GetLocalSqlServerInstancesByReadingRegInstanceNames},
    				{"CallSqlCmd", GetLocalSqlServerInstancesByCallingSqlCmd},
    			};
    
    			Dictionary<string, List<string>> dictionary = methods
    				.AsParallel()
    				.ToDictionary(v => v.Key, v => v.Value().OrderBy(n => n, StringComparer.OrdinalIgnoreCase).ToList());
    
    			foreach (KeyValuePair<string, List<string>> pair in dictionary)
    			{
    				Console.WriteLine(string.Format("~~{0}~~", pair.Key));
    				pair.Value.ForEach(v => Console.WriteLine(" " + v));
    			}
    
    			Console.WriteLine("Press any key to continue.");
    			Console.ReadKey();
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByCallingSqlBrowser()
    		{
    			DataTable dt = SmoApplication.EnumAvailableSqlServers(true);
    			return dt.Rows.Cast<DataRow>()
    				.Select(v => v.Field<string>("Name"))
    				.ToList();
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByCallingSqlWmi32()
    		{
    			return LocalSqlServerInstancesByCallingSqlWmi(ProviderArchitecture.Use32bit);
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByCallingSqlWmi64()
    		{
    			return LocalSqlServerInstancesByCallingSqlWmi(ProviderArchitecture.Use64bit);
    		}
    
    		private static List<string> LocalSqlServerInstancesByCallingSqlWmi(ProviderArchitecture providerArchitecture)
    		{
    			try
    			{
    				ManagedComputer managedComputer32 = new ManagedComputer();
    				managedComputer32.ConnectionSettings.ProviderArchitecture = providerArchitecture;
    
    				const string defaultSqlInstanceName = "MSSQLSERVER";
    				return managedComputer32.ServerInstances.Cast<ServerInstance>()
    					.Select(v =>
    						(string.IsNullOrEmpty(v.Name) || string.Equals(v.Name, defaultSqlInstanceName, StringComparison.OrdinalIgnoreCase)) ?
    							v.Parent.Name : string.Format("{0}\\{1}", v.Parent.Name, v.Name))
    					.OrderBy(v => v, StringComparer.OrdinalIgnoreCase)
    					.ToList();
    			}
    			catch (SmoException ex)
    			{
    				Console.WriteLine(ex.Message);
    				return new List<string>();
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				return new List<string>();
    			}
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByReadingRegInstalledInstances()
    		{
    			try
    			{
    				// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\InstalledInstances
    				string[] instances = null;
    				using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
    				{
    					if (rk != null)
    					{
    						instances = (string[])rk.GetValue("InstalledInstances");
    					}
    
    					instances = instances ?? new string[] { };
    				}
    
    				return GetLocalSqlServerInstances(instances);
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				return new List<string>();
    			}
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByReadingRegInstanceNames()
    		{
    			try
    			{
    				// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL
    				string[] instances = null;
    				using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
    				{
    					if (rk != null)
    					{
    						instances = rk.GetValueNames();
    					}
    
    					instances = instances ?? new string[] { };
    				}
    
    				return GetLocalSqlServerInstances(instances);
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				return new List<string>();
    			}
    		}
    
    		private static List<string> GetLocalSqlServerInstances(string[] instanceNames)
    		{
    			string machineName = Environment.MachineName;
    
    			const string defaultSqlInstanceName = "MSSQLSERVER";
    			return instanceNames
    				.Select(v =>
    					(string.IsNullOrEmpty(v) || string.Equals(v, defaultSqlInstanceName, StringComparison.OrdinalIgnoreCase)) ?
    						machineName : string.Format("{0}\\{1}", machineName, v))
    				.ToList();
    		}
    
    		private static List<string> GetLocalSqlServerInstancesByCallingSqlCmd()
    		{
    			try
    			{
    				// SQLCMD -L
    				int exitCode;
    				string output;
    				CaptureConsoleAppOutput("SQLCMD.exe", "-L", 200, out exitCode, out output);
    
    				if (exitCode == 0)
    				{
    					string machineName = Environment.MachineName;
    
    					return output.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
    						.Select(v => v.Trim())
    						.Where(v => !string.IsNullOrEmpty(v))
    						.Where(v => string.Equals(v, "(local)", StringComparison.Ordinal) || v.StartsWith(machineName, StringComparison.OrdinalIgnoreCase))
    						.Select(v => string.Equals(v, "(local)", StringComparison.Ordinal) ? machineName : v)
    						.Distinct(StringComparer.OrdinalIgnoreCase)
    						.ToList();
    				}
    
    				return new List<string>();
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex);
    				return new List<string>();
    			}
    		}
    
    		private static void CaptureConsoleAppOutput(string exeName, string arguments, int timeoutMilliseconds, out int exitCode, out string output)
    		{
    			using (Process process = new Process())
    			{
    				process.StartInfo.FileName = exeName;
    				process.StartInfo.Arguments = arguments;
    				process.StartInfo.UseShellExecute = false;
    				process.StartInfo.RedirectStandardOutput = true;
    				process.StartInfo.CreateNoWindow = true;
    				process.Start();
    
    				output = process.StandardOutput.ReadToEnd();
    
    				bool exited = process.WaitForExit(timeoutMilliseconds);
    				if (exited)
    				{
    					exitCode = process.ExitCode;
    				}
    				else
    				{
    					exitCode = -1;
    				}
    			}
    		}
    	}
    }
