		System.Reflection.Assembly thisExe;
		thisExe = System.Reflection.Assembly.GetExecutingAssembly();
		System.IO.Stream file = thisExe.GetManifestResourceStream("Namespace.Filename");
		byte[] data = Properties.Resources.Filename;
		file.Read(data, 0, data.Length);
