    Thread thRegion1 = new Thread(() =>
            {
                if (shawRegion1.Trim().Length > 0)
                {
                    returnMessage = ProcessMessage(string.Format(queueName, 
                                                                 shawRegion1));
                    Logger.Log(returnMessage);
                }
            });
    thRegion1.Start();
    if (shawRegion2.Trim().Length > 0)
    {
        returnMessage = ProcessMessage(string.Format(queueName, shawRegion2));
        Logger.Log(returnMessage);
    }
    thRegion1.Join();
