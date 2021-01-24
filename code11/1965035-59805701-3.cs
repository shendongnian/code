    List<string> lines = new List<string>();
    int maxLines = 99;
    long seekPosition = 0;
    bool fileLoaded = false;
    string line;
    
    while (!fileLoaded)
    {
        using (Stream stream = File.Open(fileName, FileMode.Open))
        {
            //Jump back to the previous position
            stream.Seek(seekPosition, SeekOrigin.Begin);
    
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream && lines.Count < maxLines)
                {
                    line = reader.ReadLine();
                    seekPosition += line.Length; //Tracks how much data has been read.
                    lines.Add(line);
                }
                fileLoaded = reader.EndOfStream;
            }
        }
    
        DoSomethingWithLines(lines);
        lines.Clear();
    }
