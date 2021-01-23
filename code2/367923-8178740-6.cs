    private void StartExecute(Object sender, EventArgs e)
    {
      ConcreteWorker.OnCreate += Create;
      ConcreteWorker.OnFinish += Finished;
      ConcreteWorker.OnInitialize += Initialize;
        var task = new Task<bool>(ConcreteWorker.Execute);
        task.Start();
        task.ContinueWith(c_task =>
        {
          ((frmWorker)WorkerView).DialogResult = System.Windows.Forms.DialogResult.OK;
        });
    }
