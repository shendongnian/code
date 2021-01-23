	void Main()
	{
		bool available = QuickBestGuessAboutAccessibilityOfPath(@"\\vault2\vault2\dir1\dir2");
		Console.WriteLine(available);
	}
	
	public static bool QuickBestGuessAboutAccessibilityOfNetworkPath(string path)
	{
		if (string.IsNullOrEmpty(path)) return false;
		string pathRoot = Path.GetPathRoot(path);
		if (string.IsNullOrEmpty(pathRoot)) return false;
		ProcessStartInfo pinfo = new ProcessStartInfo("net", "use");
		pinfo.CreateNoWindow = true;
		pinfo.RedirectStandardOutput = true;
		pinfo.UseShellExecute = false;
		string output;
		using (Process p = Process.Start(pinfo)) {
			output = p.StandardOutput.ReadToEnd();
		}
		foreach (string line in output.Split('\n'))
		{
			if (line.Contains(pathRoot) && line.Contains("OK"))
			{
				return true; // shareIsProbablyConnected
			}
		}
		return false;
	}
