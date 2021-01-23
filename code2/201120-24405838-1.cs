	public static bool ExistsOnPath(string exeName)
	{
		try
		{ 
			using (Process p = new Process()) 
			{
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.FileName = "where";
				p.StartInfo.Arguments = exeName;
				p.Start();
				p.WaitForExit();
				return p.ExitCode == 0;	
			}
		}
		catch(Win32Exception)
		{
			throw new Exception("'where' command is not on path");
		}	
	}
	public static string GetFullPath(string exeName)
	{
		try
		{ 
			using (Process p = new Process()) 
			{
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.FileName = "where";
				p.StartInfo.Arguments = exeName;
        	    p.StartInfo.RedirectStandardOutput = true;
				p.Start();
        	    string output = p.StandardOutput.ReadToEnd();
				p.WaitForExit();
			
				if (p.ExitCode != 0)
					return null;
			
				// just return first match
				return output.Substring(0, output.IndexOf(Environment.NewLine));
			}
		}
		catch(Win32Exception)
		{
			throw new Exception("'where' command is not on path");
		}	
	}
	
