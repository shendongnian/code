    public static Process CreateProcess(string exePath, string arguments = null, bool isHidden = true, string workingDirectory = null)
    		{
    			ProcessStartInfo processStartInfo = new ProcessStartInfo
    			{
    				FileName = exePath,
    				Arguments = arguments,
    				UseShellExecute = false,
    				RedirectStandardOutput = true,
    				RedirectStandardError = true,
    				WorkingDirectory = workingDirectory ?? Path.GetDirectoryName(exePath)
    			};
    
    			if (isHidden)
    				processStartInfo.CreateNoWindow = true;
    
    			return new Process()
    			{
    				StartInfo = processStartInfo,
    				EnableRaisingEvents = true
    			};
    		}
    
    		public static void RunProcess(string exePath, string arguments = null, bool isHidden = true, string workingDirectory = null)
    		{
    			Process process = CreateProcess(exePath, arguments, isHidden, workingDirectory);
    			if (process.Start())
    			{
    				process.BeginOutputReadLine();
    				process.BeginErrorReadLine();
    				process.WaitForExit();
    			}
    
    			
    		}
