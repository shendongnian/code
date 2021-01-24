            int ThreadNumber = i;
            Task.Run(async () =>
            {
                try
                {
                    Console.WriteLine("Thread #" + ThreadNumber + " started");
                    Page p = await Browser.NewPageAsync(); //exits here
                    await p.GoToAsync("https://www.google.com");
                    Console.WriteLine("Content:\n" + await p.GetContentAsync());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Thread #" + ThreadNumber + " failed. " + e);
                    throw;
                }
            });
