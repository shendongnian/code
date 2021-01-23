    public void Execute()
    {
        var reader = GetLines();
        using (var enumerator = reader.GetEnumerator())
        {
            enumerator.MoveNext();
            File.AppendAllLines("file1.dat", enumerator.Current);
            enumerator.MoveNext();
            File.AppendAllLines("file2.dat", enumerator.Current);
        }
    }
