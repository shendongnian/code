    string fileContent = Resource.text;
    using (var reader = new StringReader(fileContent))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] split = line.Split('|');
            string name = split[0];
            string lastname = split[1];
        }
    }
