    try
    {
        List<string> inputFileLines = GetInputFileFormatted(mailFile);
        if(inputFileLines == null)
           System.Windows.Forms.Application.Exit();
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("File not found");
        System.Windows.Forms.Application.Exit();
    }
