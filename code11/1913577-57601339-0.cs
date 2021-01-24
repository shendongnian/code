    // Get the files
    var fileEntries = Directory.GetFiles(path);
    
    // iterate through each file name
    foreach (var entry in fileEntries)
    {
    
      // Load the File into the lines array
      var lines = File.ReadAllLines(entry);
    
      // Iterate over each line
      for (var index = 0; index < lines.Length; index++)
      {
         // Split the lines by tab
         var split = lines[index].Split('\t');
         // your code should be at array index 1
         split[1] = "STRINGTOENTER";
         // write the whole line back
         lines[index] = string.Join("\t", split);
      }
    
      // write the file
      File.WriteAllLines(entry, lines);
    }
