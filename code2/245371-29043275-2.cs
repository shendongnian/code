    object timerBodyRunning = new object();
    timerBodyRunning = false;
    System.Timers.Timer timerFrequency100MS = new System.Timers.Timer();
    timerFrequency100MS.Interval = FREQUENCY_MS; //it will fire every 100 milliseconds
    timerFrequency100MS.Elapsed += new System.Timers.ElapsedEventHandler(oneHundredMS_Elapsed);
    timerFrequency100MS.Start();
