     private void Form1_Load(object sender, EventArgs e)
    {
      Task t = new Task(() => StartUpdate());
      t.Start();
      t.ContinueWith(task => Console.WriteLine("Done loading"));
    }
     private void StartUpdate()
    {
      for (int i = 1; i <= 100; i++)
      {
        UpdateProgressBar(i);
      }
    }
    private void UpdateProgressBar(int i)
    {
      if (progressBar1.InvokeRequired)
      {
        progressBar1.Invoke(new Action<int>(UpdateProgressBar), new Object[] { i });
      }
      else
      {
        Thread.Sleep(200);
        progressBar1.Refresh();
        progressBar1.Value = i;
        progressBar1.CreateGraphics().DrawString(i.ToString() + "%", new Font("Arial",
                                              (float)10.25, FontStyle.Bold),
                                              Brushes.Red, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
      }
    } 
