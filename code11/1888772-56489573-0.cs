    /*
        using System;
        using System.IO;
        using System.Text.RegularExpressions;
    */
    
    
    void ReadFile(string filePath) {
        var fileInfo = default(FileInfo);
        var separator = @"[;\s:,]"; // This is a simple RegEx, can be done otherwise. This allows for a little more robustness IMO
    
        // VERY rudimentary error detection
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException(nameof(filePath), "The path to the file must not be null or empty!");
        
        try {
            fileInfo = new FileInfo(filePath);
        } catch {
            throw new ArgumentException(nameof(filePath), "A valid path must be given!");
        }
    
        if (!fileInfo.Exists) {
            throw new IOException(string.Format("The file {0} does not exist!", filePath));
        }
        // END VERY rudimentary error checking
    
        var numberStrings = Regex.Split(File.ReadAllText(fileInfo.FullName), separator);
        // numberStrings is now an array of strings
    
        foreach (var numString in numberStrings) {
            if (decimal.TryParse(numString, out var myDecimal)) {
                // Do something w/ number
            } else {
                Debug.WriteLine("{0} is NaN!", numString);
            }
        }
    
    }
