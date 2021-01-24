    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    string filePath = Dts.Variables["User::FilePath"].Value.ToString();
    
    List<String> outputRecords = new List<String>();
    if (File.Exists(filePath))
    {
     using (StreamReader rdr = new StreamReader(filePath))
     {
      string line;
      while ((line = rdr.ReadLine()) != null)
      {
          if (line.Contains(","))
          {
              string[] split = line.Split(',');
    
           //replace double qoutes between text
           line = Regex.Replace(line, "(?<!(,|^))\"(?!($|,))", x => x.Value.Replace("\"", ""));
    
          }
          outputRecords.Add(line);
        }
     }
    
     using (StreamWriter sw = new StreamWriter(filePath, false))
     {
         //write filtered records back to file
         foreach (string s in outputRecords)
             sw.WriteLine(s);
      }
    }
