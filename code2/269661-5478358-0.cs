    public void Execute()
    {
        var reader = GetLines();
        int i = 0;
        foreach (var inner in reader)
        {
            if (i % 2 == 0)
                File.AppendAllLines("file1.dat", inner);
            else
                File.AppendAllLines("file2.dat", inner);
            ++i;
        }
    }
