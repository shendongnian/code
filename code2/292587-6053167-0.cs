    using (StreamReader sr = new StreamReader("TestFile.txt"))
    {
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            s=...
        }
    }
