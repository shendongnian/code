    public async IAsyncEnumerable<string> SomeSortOfAwesomeness()
    {
       foreach (var line in File.ReadLines("Filename.txt"))
       {
           // simulates an async workload, 
           // otherwise why would be using IAsyncEnumerable?
           // -- added due to popular demand 
           await Task.Delay(100);
           yield return line;
       }
    }
