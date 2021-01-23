      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
             // also use sender as backgroundworker
            int i = 0;
            foreach (MusicNote music in this.staff.Notes)
            {
                if(backgroundWorker1.CancellationPending) return;
                 music.Play(music.Dur);
                Thread.Sleep(music.getInterval(music.Dur));
                
                int p =  (int) (i*100/ staff.Notes.Count); /*Count or Length */
                backgroundWorker1.ReportProgress(p);
                i++;
            }
            backgroundWorker1.ReportProgress(100);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
 
