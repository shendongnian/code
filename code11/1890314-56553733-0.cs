    /// <summary>
    ///     Creates an enumeration of every line in a file.
    /// </summary>
    /// <param name="filePath">Path to file.</param>
    /// <returns>Enumeration of lines in specified file.</returns>
    private IEnumerable<string> GetFileLines(string filePath)
    {
        // Open the file.
        var fileStream = new System.IO.StreamReader(filePath);
        
        // Read each line.
        string line;
        while ((line = fileStream.ReadLine()) != null) yield return line;
        
        // Shut it down!
        fileStream.Close();
    }
