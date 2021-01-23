			OperatingSystem os = Environment.OSVersion;
			Version osVer = os.Version;
			Console.WriteLine(osVer.Build);
			Console.WriteLine(osVer.Major);
			Console.WriteLine(osVer.MajorRevision);
			Console.WriteLine(osVer.Minor);
			Console.WriteLine(osVer.MinorRevision);
			Console.WriteLine(osVer.Revision); 
