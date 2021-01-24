    async Task MoveMouse(Point pt)
    {
        //magically move mouse to point - ONLY MOVE it
    }
    async Task TypeCharacter(char ch)
    {
        //magically type a character - only type it
    }
    async Task PrintToTextBox(string text)
    {
        foreach(var ch in text)
        {
           await TypeCharacter(ch);
           Task.Wait(randomizer.Next(125, 225));
        }
    }
    void Start()
    {
       Task.Run(async () => await DoWork());
       //or maybe simple: Task.Run(() => DoWork());
       //it really depends on your context, you can do a deadlock
    }
    async Task DoWork()
    {
        for(...)
        {
           await MouseMove(pt);
           Task.Wait(waitMs); //wait for several miliseconds or TimeSpan
           
           await PrintToTextBox(textToPrint);
           Task.Wait(waitAfterPrintingMs);
           await MouseMove(pt2);
           //...
        }
    }
    
