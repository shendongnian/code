    Parallel.Invoke(
        () =>
        {
           string region1 = Config.AppSettings["Region1"];
           if(region1.Trim().Length > 0)
           {
                string region1ReturnMessage = ProcessMessage(string.Format(queueName, region1));
                Logger.Log(region1ReturnMessage);
           }
        },
        () =>
        {
           string region2 = Config.AppSettings["Region2"];
           if(region2.Trim().Length > 0)
           {
                string region2ReturnMessage = ProcessMessage(string.Format(queueName, region2));
                Logger.Log(region2ReturnMessage);
           }
        });
