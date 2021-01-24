    // Get the files
    var fileEntries = Directory.GetFiles(path);
    
    // iterate through each file name
    foreach (var entry in fileEntries)
    {
    
      // Load the File into the lines array
      var lines = File.ReadAllLines(entry);
    
      // Iterate over each line
      if(lines.Length >1)
      {
         // Split the lines by tab
         var split = lines[1].Split('\t');
         // your code should be at array index 1
         split[1] = "STRINGTOENTER";
         // write the whole line back
         lines[1] = string.Join("\t", split);
    
         // write the file
         File.WriteAllLines(entry, lines);
      }
    }
