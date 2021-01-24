    public void ParseFile(string fileLocation)
    {
       string[] lines = File.ReadAllLines(fileLocation);
       
       foreach(var line in lines)
       {
           string[] parts = var Regex.Split(line, "(?((?<!E)-)| )");
    
           if(parts.Any())
           {
              int first = int.Parse(parts[0]);
    
              double[] others = parts.Skip(1).Select(a => double.Parse(a)).ToArray();
           }
       }
    }   
