	public bool RunCommand<T>(string command, Func<string, string, T> output,out T outputResult, params string[] args)
	{
		string logParams = "-zprog=MyApp -zversion=1.1";
		Process proc = new Process();
		proc.StartInfo.WorkingDirectory = "";
		proc.StartInfo.FileName = "p4.exe";
		proc.StartInfo.Arguments = logParams + " " + command + " ";
		foreach (string s in args)
		{
			proc.StartInfo.Arguments += s + " ";
		}
		proc.StartInfo.UseShellExecute = false;
		proc.StartInfo.CreateNoWindow = true;
		proc.StartInfo.RedirectStandardOutput = true;
		proc.StartInfo.RedirectStandardError = true;
		proc.Start();
		StreamReader strOutput = proc.StandardOutput;
		StreamReader strError = proc.StandardError;
		outputResult = output(strOutput.ReadToEnd(), strError.ReadToEnd());
		proc.WaitForExit();
		return true;
	}
