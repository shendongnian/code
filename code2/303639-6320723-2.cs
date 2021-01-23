        public void FillItem()
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.DoWork += (a, b) =>
                                         {
                                             int i = 0; //Percentage complete, roll your own logic.
                                             foreach (var eventLog in EventLog.GetEventLogs())
                                             {
                                                 foreach (EventLogEntry entry in eventLog.Entries)
                                                 {
                                                     this.listBox1.Items.Add(entry.Message);
     uiContext.Post(z=>worker.ReportProgress(i++),null);
                                                     
                                                 }
                                             }
        
        
                                         };
                    worker.RunWorkerAsync();
                    worker.ProgressChanged += (a, b) => this.progressBar1.Value = b.ProgressPercentage;
        
        
                }
