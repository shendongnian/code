    using (var dataReader = File.OpenText(@"path\to\data\file"))
    using (var labelReader = File.OpenText(@"path\to\label\file"))
    using (var writer = File.CreateText(@"path\to\output\file"))
    {
        string line;
        while ((line = dataReader.ReadLine()) != null)
        {
            if (Regex.IsMatch(line, @"^\d+"))
            {   // found the line (append label)
                writer.WriteLine(line + " " + labelReader.ReadLine());
            }
            else
            {   // not the line (pass through)
                writer.WriteLine(line);
            }
        }
    }
