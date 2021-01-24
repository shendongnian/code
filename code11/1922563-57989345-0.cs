    public async Task SaveCountAsync(int count)
    {
        var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
        using (var writer = File.CreateText(backingFile))
        {
            await writer.WriteLineAsync(count.ToString());
        }
    }
