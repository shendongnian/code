    static int CreateTestData(string fileName)
    {
        FileStream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.WriteThrough);
        using (StreamWriter writer = new StreamWriter(fstream, Encoding.UTF8))
        {
            for (int i = 0; i < linecount; i++)
            {
                writer.WriteLine("{0} {1}", 1.1d + i, i);
            }
        }
        return linecount;
    }
    static int PrintTestData(string fileName)
    {
        for (int i = 0; i < linecount; i++)
        {
            String.Format("{0} {1}", 1.1d + i, i);
        }
        return linecount;
    }
