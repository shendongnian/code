	XmlDocument document = new XmlDocument();
	try
	{
		document.Load(folderPath + @"\XMLfile.xml"); // folderPath variable is assigned before depending on user input
	}
	catch (Exception ex) when (ex is System.IO.DirectoryNotFoundException || ex is System.IO.FileNotFoundException)
	{
		// if folder doesn't exist then the file will not either
		System.IO.Directory.CreateDirectory(folderPath);
		document.LoadXml("<?xml version=\"1.0\"?> \n" +
						 "<elements> \n" +
						 "</elements>");
	}
