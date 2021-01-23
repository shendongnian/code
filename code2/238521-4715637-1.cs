    string inputFileName = ""; // Use a sensible file name.
	string outputFileName = ""; // Use a sensible file name.
	File.Copy(inputFileName, outputFileName, true);
	using (StreamReader reader = new StreamReader(inputFileName))
	{
		string line = null;
		int inputLinesIndex = 0;
		while ((line = reader.ReadLine()) != null)
		{
			string convertedLine = ConvertLine(line);
			string[] outputFileLines = File.ReadAllLines(outputFileName);
			if (inputLinesIndex < outputFileLines.Length)
			{
				outputFileLines[inputLinesIndex] = convertedLine;
				File.WriteAllLines(outputFileName, outputFileLines);
			}
			inputLinesIndex++;
		}
	}
