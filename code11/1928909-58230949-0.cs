    using (StreamWriter writeToFile = new StreamWriter(@"igxSpec.csv"))
    {
        foreach (string line in csv)
        {
            writeToFile.WriteLine(line);
        }
    }
