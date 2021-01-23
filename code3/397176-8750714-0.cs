    using(CustomForm myForm = new CustomForm())
    {
      myForm.FormClosed += new FormClosedEventHandler(ChildFormClosed);
      myForm.Show(theFormOwner);
      myForm.Refresh();
      while(aBackgroundWorker.IsBusy)
      {
        Thread.Sleep(1);
        Application.DoEvents();
      }
    }
    void ChildFormClosed(object sender, FormClosedEventArgs e)
    {
        aBackgroundWorker.CancelAsync();
    }
