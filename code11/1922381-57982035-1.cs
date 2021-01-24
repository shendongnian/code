    Task[] Tasks = new Task[1];
    for (int i = 0; i < Tasks.Length; i++)
    {
        int ThreadNumber = i;
        Tasks[i] = Task.Run(async () =>
        {
           Browser browser = await Puppeteer.LaunchAsync
           (
               new LaunchOptions
               {
                    Headless = true,
                   ExecutablePath = "Chromium\\chrome.exe"
               }
           );
           Page page = await browser.NewPageAsync(); //creates as expected
        });
    }
    
    Task.WaitAll(Tasks);
