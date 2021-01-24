     List<string> inputFileLines = null;
     try
        {
            inputFileLines = GetInputFileFormatted(mailFile);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found");
        }
