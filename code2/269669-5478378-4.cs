    public void Execute()
    {
        var reader = GetLines();
    
        var evenLines = reader.Where((str, i) => i % 2 == 0);
        var oddLines = reader.Where((str, i) => i % 2 != 0);
    
        foreach (string line in evenLines)
            File.AppendAllLines("file1.dat", line);
    
        foreach (string line in oddLines)
            File.AppendAllLines("file2.dat", line);
    }
