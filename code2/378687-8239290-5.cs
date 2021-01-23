    void ShowMessageBox(CancellationTokenSource cts)
    { 
        if(MessageBox.Show("StopThread",
        "Abort",MessageBoxButtons.YesNo,
         MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        {
          cts.Cancel();
      }       
    }
