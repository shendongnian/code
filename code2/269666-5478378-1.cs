    public void Execute()
    {
        var reader = GetLines();
        int index = 0;
        foreach (string line in reader)
        {
            if ((index % 2) == 0)
                File.AppendAllLines("file1.dat", line);
            else
                File.AppendAllLines("file2.dat", line);
            index++;
        }
    }
