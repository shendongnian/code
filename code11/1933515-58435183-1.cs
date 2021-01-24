    line = reader.ReadLine();
    while (line != null)
    {
        if (line.Contains("@"))
            myEmails.Add(line);
    
        line = reader.ReadLine();
    }
    reader.Close();
