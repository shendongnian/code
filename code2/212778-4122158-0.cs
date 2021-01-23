    using (var reader = File.OpenText("<< filename >>"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            // Process the different parts of the line here.
        }
    }
