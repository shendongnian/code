    Dictionary<string, string> LoadSmileys(string fileName)
    {
        var smileys = new Dictionary<string, string>();
        using (var reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < parts.Length; i++)
                {
                    smileys[parts[i]] = parts[0];
                }
            }
        }
        return smileys;
    }
