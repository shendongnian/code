    public void TaskOnClick() //getting multi-values
        {
           string filename = "Assets/Text/TEMP/multi-export.txt";            
           var tempratures = File.ReadAllLines("Assets/Text/multi-import.txt")
                             .Select(GetTemperatureByRegex).ToArray();
           File.WriteAllLines(filename,tempratures); // it creates a new file or overwrites
           
         }    
