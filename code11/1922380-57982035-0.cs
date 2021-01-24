    Task[] Tasks = new Task[1];
    Browser browser = await Puppeteer.LaunchAsync
    (
        new LaunchOptions
        {
            Headless = true,
            ExecutablePath = "Chromium\\chrome.exe"
        }
    );
    for (int i = 0; i < Tasks.Length; i++)
    {
        int ThreadNumber = i;
        Tasks[i] = Task.Run(async () =>
        {
           Page page = await browser.NewPageAsync(); //stucks
        });
    }
    
    Task.WaitAll(Tasks);
