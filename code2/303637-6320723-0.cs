    public void FillItem()
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (a, b) =>
                                     {
                                         foreach (var eventLog in EventLog.GetEventLogs())
                                         {
                                             foreach (EventLogEntry entry in eventLog.Entries)
                                             {
                                                 this.listBox1.Items.Add(entry.Message);
                                             }
                                         }
    
    
                                     };
                worker.RunWorkerAsync();
    
            }
