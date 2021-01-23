        catch(Exception ex)
        {
            //All the exceptions are handled and written in the EventLog. 
            EventLog log = new EventLog("Application");
            log.Source = "MFDBAnalyser";
            log.WriteEntry(ex.Message);
        }
