    var sb = new StringBuilder();
                
    using (var sr = new StreamReader("PATH TO INPUT FILE"))
    {
        var line = sr.ReadLine();
    
        while (line != null)
        {
            sb.AppendLine(line);
    
            if (line.Contains("[names]"))
            {
                sr.Close();
            }
            else
            {
                line = sr.ReadLine();
            }
        }
    }
    
    File.WriteAllText("PATH TO INPUT FILE", sb.ToString());
