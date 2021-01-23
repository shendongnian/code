	using System;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Diagnostics;
	using System.Threading;
	namespace Resolv.Extensions.System.UI
	{
		public static class ShellHelpers
		{
			private const long FindExecutable_SE_ERR_FNF = 2;           //The specified file was not found.
			private const long FindExecutable_SE_ERR_PNF = 3;           // The specified path is invalid.
			private const long FindExecutable_SE_ERR_ACCESSDENIED = 5;  // The specified file cannot be accessed.
			private const long FindExecutable_SE_ERR_OOM = 8;           // The system is out of memory or resources.
			private const long FindExecutable_SE_ERR_NOASSOC = 31;      // There is no association for the specified file type with an executable file.
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern bool SetForegroundWindow(IntPtr hWnd);
			[DllImport("shell32.dll", EntryPoint = "FindExecutable")]
			private static extern long FindExecutableA(string lpFile, string lpDirectory, StringBuilder lpResult);
			private class ProcessInfo
			{
				public string ProcessPath { get; set; }
				public Process Process { get; set; }
			}
			/// <summary>
			/// Opens the specified file in the default associated program, and sets focus to 
			/// the opened program window. The focus setting is required for applications, 
			/// such as Microsoft Excel, which re-use a single process and may not set focus 
			/// when opening a second (or third etc) file.
			/// </summary>
			/// <param name="filePath"></param>
			/// <returns></returns>
			public static bool OpenFileWithFocus(string filePath)
			{
				string exePath;
				if (!TryFindExecutable(filePath, out exePath))
				{
					return false;
				}
				Process viewerProcess = new Process();
				viewerProcess.StartInfo.FileName = exePath;
				viewerProcess.StartInfo.Verb = "open";
				viewerProcess.StartInfo.ErrorDialog = true;
				viewerProcess.StartInfo.Arguments = filePath;
				ProcessInfo info = new ProcessInfo() {Process = viewerProcess, ProcessPath = exePath};
				viewerProcess.Start();
				ThreadPool.QueueUserWorkItem(SetWindowFocusForProcess, info);
				return true;
			}
			/// <summary>
			/// To be run in a background thread: Attempts to set focus to the 
			/// specified process, or another process from the same executable.
			/// </summary>
			/// <param name="processInfo"></param>
			private static void SetWindowFocusForProcess(object processInfo)
			{
				ProcessInfo windowProcessInfo = processInfo as ProcessInfo;
				if (windowProcessInfo == null)
					return;
				int tryCount = 0;
				Process process = windowProcessInfo.Process;
				while (tryCount < 5)
				{
					try
					{
						process.WaitForInputIdle(1000);         // This may throw an exception if the process we started is no longer running
						IntPtr hWnd = process.MainWindowHandle;
						if (SetForegroundWindow(hWnd))
						{
							break;
						}
					}
					catch
					{
						// Applications that ensure a single process will have closed the 
						// process we opened earlier and handed the command line arguments to 
						// another process. We should find the "single" process for the 
						// requested application.
						if (process == windowProcessInfo.Process)
						{
							Process newProcess = GetFirstProcessByPath(windowProcessInfo.ProcessPath);
							if (newProcess != null)
								process = newProcess;
						}
					}
					tryCount++;
				}
			}
			/// <summary>
			/// Gets the first process (running instance) of the specified 
			/// executable.
			/// </summary>
			/// <param name="executablePath"></param>
			/// <returns>A Process object, if any instances of the executable could be found running - otherwise NULL</returns>
			public static Process GetFirstProcessByPath(string executablePath)
			{
				Process result;
				if (TryGetFirstProcessByPath(executablePath, out result))
					return result;
				return null;
			}
			/// <summary>
			/// Gets the first process (running instance) of the specified 
			/// executable
			/// </summary>
			/// <param name="executablePath"></param>
			/// <param name="process"></param>
			/// <returns>TRUE if an instance of the specified executable could be found running</returns>
			public static bool TryGetFirstProcessByPath(string executablePath, out Process process)
			{
				Process[] processes = Process.GetProcesses();
				foreach (var item in processes)
				{
					if (string.Equals(item.MainModule.FileName, executablePath, StringComparison.InvariantCultureIgnoreCase))
					{
						process = item;
						return true;
					}
				}
				process = null;
				return false;
			}
			/// <summary>
			/// Return system default application for specified file
			/// </summary>
			/// <param name="filePath"></param>
			/// <returns></returns>
			public static string FindExecutable(string filePath)
			{
				string result;
				TryFindExecutable(filePath, out result, raiseExceptions: true);
				return result;
			}
			/// <summary>
			/// Attempts to find the associated application for the specified file
			/// </summary>
			/// <param name="filePath"></param>
			/// <param name="executablePath"></param>
			/// <returns>TRUE if an executable was associated with the specified file. FALSE 
			/// if there was an error, or an association could not be found</returns>
			public static bool TryFindExecutable(string filePath, out string executablePath)
			{
				return TryFindExecutable(filePath, out executablePath, raiseExceptions: false);
			}
			/// <summary>
			/// Attempts to find the associated application for the specified file. Throws 
			/// exceptions if the file could not be opened or does not exist, but returns 
			/// FALSE when there is no application associated with the file type.
			/// </summary>
			/// <param name="filePath"></param>
			/// <param name="executablePath"></param>
			/// <param name="raiseExceptions"></param>
			/// <returns></returns>
			public static bool TryFindExecutable(string filePath, out string executablePath, bool raiseExceptions)
			{
				// Anytime a C++ API returns a zero-terminated string pointer as a parameter 
				// you need to use a StringBuilder to accept the value instead of a 
				// System.String object.
				StringBuilder oResultBuffer = new StringBuilder(1024);
				long lResult = 0;
				lResult = FindExecutableA(filePath, string.Empty, oResultBuffer);
				if (lResult >= 32)
				{
					executablePath = oResultBuffer.ToString();
					return true;
				}
				switch (lResult)
				{
					case FindExecutable_SE_ERR_NOASSOC:
						executablePath = "";
						return false;
					case FindExecutable_SE_ERR_FNF:
					case FindExecutable_SE_ERR_PNF:
						if (raiseExceptions)
						{
							throw new Exception(String.Format("File \"{0}\" not found. Cannot determine associated application.", filePath));    
						}
						break;
					case FindExecutable_SE_ERR_ACCESSDENIED:
						if (raiseExceptions)
						{
							throw new Exception(String.Format("Access denied to file \"{0}\". Cannot determine associated application.", filePath));    
						}
						break;
					default:
						if (raiseExceptions)
						{
							throw new Exception(String.Format("Error while finding associated application for \"{0}\". FindExecutableA returned {1}", filePath, lResult));
						}
						break;
				}
				executablePath = null;
				return false;
			}
		}
	}
