    public async IAsyncEnumerable<string> SomeSortOfAwesomeness()
    {
       foreach (var line in File.ReadLines("Filename.txt"))
       {
           await Task.Delay(100);
           yield return line;
       }
    }
