    static async Task simpleAsync()
    {
        int i;
        try
        {
            i = await jobAsync();
        } 
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to execute jobAsync", e);
        }
        Console.WriteLine("Async done. Result: " + i.ToString());
        if(i < 0)
        {
            throw new InvalidOperationException("jobAsync returned a negative value");
        }
        await doSomethingWithResult(i);
    }
