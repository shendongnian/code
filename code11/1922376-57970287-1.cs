        ...
        static Task StartScraping(int threads)
        {
            return Task.WaitAll(
                Enumerable.Range(0, threads)
                .Select(ThreadNumber =>
                {
                    try
                    {
                        Console.WriteLine("Thread #" + ThreadNumber + " started");
                        Page p = await Browser.NewPageAsync(); //exits here
                        await p.GoToAsync("https://www.google.com");
                        Console.WriteLine("Content:\n" + await p.GetContentAsync());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Thread #" + ThreadNumber + " failed. " + e);
                        throw;
                    }
                }));
        }
        static async Task MainAsync()
        {
            await StartBrowser();
            await StartScraping(1);
        }
