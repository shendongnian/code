    void changeFormat(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    string[] allLines = File.ReadAllLines(sourcePath);
                    // Merge them in one line separated by comma
                    string convertedSingleLine = string.Join(",", allLines);
                    // Replace the " m,"
                    convertedSingleLine = convertedSingleLine.Replace(" m,",
                                          " m" + System.Environment.NewLine);
                    File.WriteAllText(destinationPath, convertedSingleLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error while manipulation the files. Exception: {ex.Message}");
            }
        }
