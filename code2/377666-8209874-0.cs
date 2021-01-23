	private static int _dot;
	private readonly string _directory;
	private static string GenDiagramFile(Digraph graph, string directory, string stem)
	{
		var dotfile = Path.Combine(directory, stem + (++_dot) + ".dot");
		var diagramFile = dotfile.Replace(".dot", ".png");
		using (var w = new StreamWriter(new FileStream(dotfile, FileMode.Create), Encoding.UTF8))
			w.WriteLine(graph.ToString(true));
		ExecuteCommand("dot", string.Format(@"""{0}"" -o ""{1}"" -Tpng", dotfile, diagramFile));
		return diagramFile;
	}
	private static void ExecuteCommand(string command, string @params)
	{
		Process.Start(new ProcessStartInfo(command, @params) {CreateNoWindow = true, UseShellExecute = false });
	}
