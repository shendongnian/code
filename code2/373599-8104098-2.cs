            bw.CancelAsync(); // ending splashing
            Application.Run(frm);
    }     
    static void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        AFirstForm splashForm = new FirstForm();
        splashForm.TopMost = true;
        splashForm.Show();
        while (!(sender as System.ComponentModel.BackgroundWorker).CancellationPending)
        {
            splashForm.Refresh();
        }
        splashForm.Close();    
        e.Result = splashForm;
    }
