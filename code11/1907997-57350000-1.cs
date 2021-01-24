    var fileName = @"C:\\Users\\Aleksa\\Desktop\\testTxt.xml";
	var outputPath = ""; // The directory in which to create your XML files.
	using (var stream = File.OpenRead(fileName))
	{
		XmlReaderExtensions.SplitDocumentFragments(stream,
												   index => Path.Combine(outputPath, index.ToString() + ".xml"),
												   (name, lineInfo) => 
												   {
                                                       Console.WriteLine("Writing {0}, starting line info: LineNumber = {1}, LinePosition = {2}...", 
																		 name, lineInfo?.LineNumber, lineInfo?.LinePosition);
												   },
												   (name, lineInfo) => 
												   {
                                                       Console.WriteLine("   Done.  Result: ");
                                                       Console.Write("   ");
                                                       Console.WriteLine(File.ReadAllText(name));
												   });
	}
