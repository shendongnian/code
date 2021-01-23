    private string taskexistance(string taskname)
    		{
    			ProcessStartInfo start = new ProcessStartInfo();
    			start.FileName = "schtasks.exe"; // Specify exe name.
    			start.UseShellExecute = false;
    			start.CreateNoWindow = true;
    			start.WindowStyle = ProcessWindowStyle.Hidden;
    			start.Arguments = "/query /TN " + taskname;
    			start.RedirectStandardOutput = true;
    			// Start the process.
    			using (Process process = Process.Start(start))
    			{
    				// Read in all the text from the process with the StreamReader.
    				using (StreamReader reader = process.StandardOutput)
    				{
    					string stdout = reader.ReadToEnd();
    					if (stdout.Contains(taskname)) {
    						return "true.";
    					}
    					else
    					{
    						return "false.";
    					}
    				}
    			}
    		}
