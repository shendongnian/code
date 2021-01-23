    using (var process = new Process())
	{
		var encoding = Encoding.GetEncoding(852);
	
		var psi = new ProcessStartInfo();
		psi.FileName = "cmd";
		psi.RedirectStandardInput = true;
		psi.RedirectStandardOutput = true;
		psi.UseShellExecute = false;
		psi.StandardOutputEncoding = encoding;
	
		process.StartInfo = psi;
	
		process.Start();
	
		using (var sr = process.StandardOutput)
		using (var sw = new StreamWriter(process.StandardInput.BaseStream, encoding))
		{
			var command = "....";
			sw.WriteLine(command);
			// etc..                   
		}
	}
