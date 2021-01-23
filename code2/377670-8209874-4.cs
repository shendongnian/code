	private static string GenDiagramFile(string pathToDotFile)
	{
		var diagramFile = pathToDotFile.Replace(".dot", ".png");
		ExecuteCommand("dot", string.Format(@"""{0}"" -o ""{1}"" -Tpng", 
                     pathToDotFile, diagramFile));
		return diagramFile;
	}
	private static void ExecuteCommand(string command, string @params)
	{
		Process.Start(new ProcessStartInfo(command, @params) {CreateNoWindow = true, UseShellExecute = false });
	}
