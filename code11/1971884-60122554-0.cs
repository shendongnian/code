    static async Task AddResultToDb(int number)
    {
        int result = ComputeResult(number); 
        AddResultToDb(number, result); 
    }
    static async Task AddResultsToDb(IEnumerable<int> numbers)
    {
        var tasks = numbers.Select
        (
            number => Task.Run( () => AddResultToDb(number) )  
        )
        .ToList();
        
        await Task.WhenAll(tasks);
    }
        
