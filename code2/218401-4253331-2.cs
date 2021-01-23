    private void Comparer(string fileLocation1, string fileLocation2, string resultFolder)
    {
        StreamReader source = new StreamReader(fileLocation1);
        StreamReader pattern = new StreamReader(fileLocation2);
        Directory.CreateDirectory(resultFolder);
        //reading patterns
        List<String> T = new List<string>();
        string line;
        while ((line = pattern.ReadLine()) != null)
            T.Add(line);
        pattern.Close();
        //finding matches and write them in output
        int counter;
        foreach (string pat in T)
        {
            StreamWriter result = File.CreateText(Path.Combine(resultFolder, pat + ".txt"));
            source.BaseStream.Position = counter = 0;
            while ((line = source.ReadLine()) != null)
            {
                if (line.Contains(pat))
                    result.WriteLine("LineNo : " + counter.ToString() + " : " + line);
                counter++;
            }
            result.Close();
        }
        source.Close();
    }
