    public static async IAsyncEnumerable<string> SomeSortOfAwesomeness()
    {
       using StreamReader reader = File.OpenText("Filename.txt");
       while(!reader.EndOfStream)
          yield return await reader.ReadLineAsync();
    }
