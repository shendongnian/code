    private void DoWork(object sender, DoWorkEventArgs e) {
                var fileCounter = Convert.ToDecimal(fileNames.Count());
                decimal i = 0;
                var Event = new AutoResetEvent(false);
                foreach (var file in fileNames) {
                    i++;
                    var generator = new Generator(assembly);
    
                    {
                        var thread = new Thread(new ThreadStart(
                                delegate() {
                                    generator.Generate(file);
                                    Event.Set();
                                }));
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        //while (thread.IsAlive); // critical point
                        Event.WaitOne();
                    }
                    GC.Collect();
                    int progress = Convert.ToInt32(Math.Round(i / fileCounter * 100));
                    backgroundWorker.ReportProgress(progress);
                }
            }
