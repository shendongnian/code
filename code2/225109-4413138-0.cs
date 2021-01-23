        if (System.Threading.Monitor.TryEnter(syncObj,10))
        {
            
            try
            {
                //CallWebService
            }
            finally
            {
                System.Threading.Monitor.Exit(syncObj);
            }
        }
        else
        {
            //Tell Client they are still waiting
        }
