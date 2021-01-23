    private void Comparer(string fileLocation1, string fileLocation2, string resultLocation)
    {
        StreamReader source = new StreamReader(fileLocation1);
        StreamReader pattern = new StreamReader(fileLocation2);
        StreamWriter result = File.CreateText(resultLocation);
        
        //reading patterns
        List<String> T = new List<string>();
        string line;
        while ((line = pattern.ReadLine()) != null)
            T.Add(line);
        pattern.Close();
        //finding matches and write them in output
        int counter = 0;
        while ((line = source.ReadLine()) != null)
        {
            foreach (string pat in T)
            {
                if (line.Contains(pat))
                {
                    result.WriteLine("LineNo : " + counter.ToString() + " : " + line);
                    break; //just if you want distinct output
                }
            }
            counter++;
        }
        
        source.Close();
        result.Close();
    }
