    private void PublishLoop()
    {
       string previousIDs = String.Empty;
       int timeout = Int32.Parse(ConfigurationManager.AppSettings["publishTimeout"]);
       while (Running)
       {                
           string currentIDs = ConcatenateList(LoadIDs());
           Dump(currentIDs);
           if (!previousIDs.Equals(currentIDs))
           {
               try
               {
                   Publish(currentIDs);
                   _log.Info("Published successfuly");
               }
               catch (PublicationException exception)
               {
                   _log.Error("Publication failed");
               }
               previousIDs = currentIDs;
           }
           Thread.Sleep(timeout);
       }
    }
