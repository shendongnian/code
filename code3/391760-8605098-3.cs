    using (FileStream str = new FileInfo("MyFilePath.txt").OpenWrite())
    {
        StreamWriter writter = new StreamWriter(str);
        foreach (string s in list)
        {
            writter.WriteLine(s);
        }
    }
