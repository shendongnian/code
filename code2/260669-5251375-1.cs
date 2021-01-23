    static Dictionary<string, StreamWriter> _FileMap = new Dictionary<string, StreamWriter>();
    static void Main(string[] args)
    {
        var data = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("Animal", "Lion|Roars"),
            new KeyValuePair<string, string>("Animal", "Tiger|Roars"),
            new KeyValuePair<string, string>("Bird", "Eagle|Flies"),
            new KeyValuePair<string, string>("Bird", "Parrot|Mimics")
        };
        foreach (var line in data) // write data to right output file
        {
            WriteLine(line.Key, line.Value);
        }
        foreach (var stream in _FileMap) // close all open files
        {
            stream.Value.Close();
        }
    }
    static void WriteLine(string key, string line)
    {
        StreamWriter writer = null;
        if (false == _FileMap.TryGetValue(key, out writer))
        {
            // Create file if it was not opened already
            writer = new StreamWriter(File.Create(key+".txt"));
            _FileMap.Add(key,writer);
        }
        writer.WriteLine(line);  // write dynamically to the right output file depending on passed key
    }
