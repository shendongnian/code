	ProcessStartInfo start = new ProcessStartInfo();
	start.FileName = @"C:\TheOtherApplication.exe"; // Specify exe name.
	start.UseShellExecute = false;
	start.RedirectStandardOutput = true;
	using (Process process = Process.Start(start))
	{
	    // Read in all the text from the process with the StreamReader.
	    using (StreamReader reader = process.StandardOutput)
	    {
		string result = reader.ReadToEnd();
		Console.Write(result);
	    }
	}
