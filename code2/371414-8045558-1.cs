    using (StreamWriter outputWriter = new StreamWriter(File.Create(strExcelOutputFilename)))
    {
    	StreamReader inputReader = new StreamReader(TextFile.FileContent);
    	string fileContent = inputReader.ReadToEnd();
    	
    	fileContent = fileContent.Replace('|', ';');
    	outputWriter.Write(fileContent);
    }
