    using System.Linq;
    
    ...
    
    Weather[] records = File
      .ReadLines(openFileDialog.FileName)
      .Skip(1)                          // Skip 1st line
      .Select(line => line.Split(','))  // Convert each line starting from the 2nd
      .Select(items => new Weather() {  // into custom Weather classes
         Outlook = items[0],            //TODO: add necessary conversions if required 
         Temperature = items[1], 
         Humidity = items[2], 
         Wind = items[3], 
         Decision = items[4]
       })
      .ToArray();                       // organized as an array
