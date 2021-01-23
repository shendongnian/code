    for (double i = progressBar_ChangeProgress.Minimum;
        i < progressBar_ChangeProgress.Maximum;
        i++)
    {
      for (int b = 0; b < 100000000; b++) { }
      Dispatcher.Invoke((ThreadStart) delegate(){                   
        progressBar_ChangeProgress.Value = i;
      });
    }
