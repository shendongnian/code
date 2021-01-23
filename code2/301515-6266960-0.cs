        static void Main(string[] args)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.WorkerSupportsCancellation = true;
                    bw.RunWorkerAsync();
                    Thread.Sleep(5000);
                    bw.CancelAsync();
                    Console.ReadLine();
                }
        
                static void bw_DoWork(object sender, DoWorkEventArgs e)
                {
                    string[] files = new string[] {"", "" };
                    foreach (string file in files)
                    { 
                        if(((BackgroundWorker)sender).CancellationPending)
                        {
                            e.Cancel = true;
                            //set this code at the end of file processing
                            return;
                        }
                    }
                }
