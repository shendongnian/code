    public void OnStart()        
    {
        Log.Write("OnStart");
        if (ValidateConfigSettings(out queuePath, out mailFrom, out SMTPSSLConfig))
        { 
            Log.Write("Validated config");
            msgQ = SetupMessageQueue(queuePath);
            Log.Write("Set up the queue obj.");
            msgQ.BeginReceive();
            Log.Write("Begun queue receive.");
            try
            {
                if (!MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Create(queuePath);
                    Log.Log("Message queue successfully created following location:" + queuePath);
                }
                else                   
                    Log.Log("Message Queue Path: " + msgQ.Path);                    
            }
            catch (Exception ex)              
                Log.WriteCommonLog("Error checking message queue existence:\n" + GetExceptionMessageString(ex));                
        }
        else
            Log.Write("Found bad config.");
            
        Log.Log("Message queue started successfully.");
    } 
