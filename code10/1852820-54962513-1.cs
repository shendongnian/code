    List<string> filecontents = new List<string>( File.ReadAllLines(filename) );
    for (int i = 0; i < filecontents.Count; i++)
    {
        if (filecontents[i].Contains(text))
        {
            string error = filecontents[i + 1];
        }
    }
