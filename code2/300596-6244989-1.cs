    using (var reader = File.OpenText(orgFileName))
    using (var writer = File.CreateText(tmpFileName))
    {
        while (true)
        {
           string line = reader.ReadLine();
           if (line == null)
             break; // done
    
           // logic to analyze / track content
           if ( Is_special_line)
           {
              // do something, or maybe nothing (skip)
           }
           else
           {
              writer.WriteLine(line);
           }
        }
    }
    
    File.Delete(orgFilename);
    File.Rename(tmpFilename, orgFilename);
