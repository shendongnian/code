    static void ChangeFormatInDestination(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    string[] allLines = File.ReadAllLines(sourcePath);
                    // Merge all non-null lines in one line separated by commas
                    var convertedSingleLine = string.Join(",", 
                                    allLines.Where(s=>!string.IsNullOrEmpty(s)));
                    // Replace the " m,"
                    convertedSingleLine = convertedSingleLine.Replace(" m,",
                                          " m" + System.Environment.NewLine);
                    File.WriteAllText(destinationPath, convertedSingleLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error while manipulating the files. Exception: {ex.Message}");
            }
        }
