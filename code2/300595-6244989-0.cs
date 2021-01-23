    using (var reader = File.OpenText(orgFileName))
    using (var writer = File.CreateText(tmpFileName))
    {
        while (true)
        {
           string line = reader.ReadLine();
           if (line == null)
             break; // done
    
           if ( Is_special_line)
           {
              // something, maybe nothing
           }
           else
           {
              writer.WriteLine(line);
           }
        }
    }
    
    File.Delete(orgFilename);
    File.Rename(tmpFilename, orgFilename);
