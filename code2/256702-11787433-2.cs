    var pinfo = new ProcessStartInfo("net", "use");
    pinfo.CreateNoWindow = true;
    pinfo.RedirectStandardOutput = true;
    pinfo.UseShellExecute = false;
    var p = Process.Start(pinfo);
    var output = p.StandardOutput.ReadToEnd();
    Console.WriteLine(output);
    var shareConnected = false;
    foreach (var line in output.Split('\n'))
    {
    	if (line.Contains(@"\\vault2") && line.Contains("OK"))
    	{
    		shareConnected = true;
    	}
    }
    Console.WriteLine(shareConnected);
