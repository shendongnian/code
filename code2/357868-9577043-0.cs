            EventLog log = new EventLog("Application");
            for (int counter = 1; counter <= sizeToGet; counter++)
            {
                string msg = log.Entries[log.Entries.Count - counter].Message;
    
                Console.WriteLine(msg)
            }
