    string inputFileName = "";
	string outputFileName = "";
	File.Copy(inputFileName, outputFileName, true);
	using (StreamReader reader = new StreamReader(inputFileName))
	{
		string line = null;
		int inputLinesIndex = 0;
		while ((line = reader.ReadLine()) != null)
		{
			// Convert line.
			string[] outputFileLines = File.ReadAllLines(outputFileName);
			if (inputLinesIndex < outputFileLines.Length)
			{
				outputFileLines[inputLinesIndex] = line;
				File.WriteAllLines(outputFileName, outputFileLines);
			}
			inputLinesIndex++;
		}
	}
