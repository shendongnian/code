    public static void FormatCSV(string csvFilePath) {
     bool foundFooter = false;
     string tempFilePath = Path.GetTempFileName();
    
     using(var sr = new StreamReader(csvFilePath)) {
      using(var sw = new StreamWriter(tempFilePath)) {
       string line;
       bool isFirstLine = true;
    
       while ((line = sr.ReadLine()) != null) {
        if (!isFirstLine && !line.StartsWith("F|")) {
         sw.WriteLine(line);
        } else if (line.StartsWith("F|")) {
         foundFooter = true;
         break; // we're now on the footer line, so don't go any further - sometimes the footer line has another blank line after it
        }
    
        isFirstLine = false;
       }
      }
     }
    
     if (foundFooter) {
      // the file did NOT previously have its header and footer removed, but that has been done just now, so go ahead and save the modified file
      File.Delete(csvFilePath);
      File.Move(tempFilePath, csvFilePath);
     } else {
      // the file previously had its header and footer removed, so do not change it
      File.Delete(tempFilePath);
     }
    
     GrantWideOpenFilePermissions(csvFilePath);
    }
