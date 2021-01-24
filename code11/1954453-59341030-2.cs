    public static Dictionary<TermDocs, float> ReadFile(string file)
    {
        var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
        Dictionary<TermDocs, float> dictionary = new Dictionary<TermDocs, float>();
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var spl = line.Split('|');
                dictionary.Add(new TermDocs { documentid = Convert.ToInt32(spl[0]), term = spl[1] }, float.Parse(spl[2]));
            }
        }
        return dictionary;
    }
