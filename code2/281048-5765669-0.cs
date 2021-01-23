    		/// <summary>
		/// run a program using the provided ProcessStartInfo
		/// </summary>
		/// <param name="processInfo"></param>
		/// <returns>Both StandardError and StandardOutput</returns>
		public static string WithOutputRedirect(System.Diagnostics.ProcessStartInfo processInfo)
		{
			string result = "";
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardError = true;
			processInfo.RedirectStandardOutput = true;
			System.Diagnostics.Process p = System.Diagnostics.Process.Start(processInfo);
			p.ErrorDataReceived += delegate(object o, System.Diagnostics.DataReceivedEventArgs e)
			{
				if (e.Data != null && e.Data != "")
				{
					result += e.Data + "\r\n";
				}
			};
			p.BeginErrorReadLine();
			p.OutputDataReceived += delegate(object o, System.Diagnostics.DataReceivedEventArgs e)
			{
				if (e.Data != null && e.Data != "")
				{
					result += e.Data + "\r\n";
				}
			};
			p.BeginOutputReadLine();
			p.WaitForExit();
			return result;
		}
