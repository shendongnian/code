    public async Task ScrapJockeys(int startIndex, int stopIndex, string dataType)
    {
        ConcurrentBag<Task> tasks = new ConcurrentBag<Task>();
        ParallelOptions parallelLoopOptions = new ParallelOptions() { CancellationToken = CancellationToken };
        Parallel.For(startIndex, stopIndex, parallelLoopOptions, i =>
        {
            int j = i;
            switch (dataType)
            {
                case "jockeysPl":
                    tasks.Add(_scrapServices.ScrapSingleJockeyPlAsync(j));
                    break;
                case "jockeysCz":
                    tasks.Add(_scrapServices.ScrapSingleJockeyCzAsync(j));
                    break;
            }
        });
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (OperationCanceledException)
        {
            //
        }
        finally
        {
            await _dataServices.SaveAllJockeysAsync(Jockeys.ToList()); //saves everything to JSON file
                                                                       //soing some stuff with UI props in here
        }
    }
