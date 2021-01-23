    private static void TrimColon(String inputFilePath, String outputFilePath)
    {
        //Error checking file paths
        if (String.IsNullOrWhiteSpace(inputFilePath))
            throw new ArgumentException("inputFilePath");
        if (String.IsNullOrWhiteSpace(outputFilePath))
            throw new ArgumentException("outputFilePath");
        //Check to see if files exist? - Up to you, I would.
        using (var streamReader = File.OpenText(inputFilePath))
        using (var streamWriter = File.AppendText(outputFilePath))
        {
            var text = String.Empty;
    
            while (!streamReader.EndOfStream)
            {
                text = streamReader.ReadLine();
                var index = text.LastIndexOf(":");
                if (index > 0)
                    text = text.Substring(0, index);
                streamWriter.WriteLine(text);
            }
        }
    }
