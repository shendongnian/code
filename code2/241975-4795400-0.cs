    ProgressBar pg = new ProgressBar();
    pg.Maximum = 100;
    pg.Step = 1;
    
    this.Controls.Add(pg);
    
    new Thread(new ThreadStart(() =>
        {
            // Replace with your code:
            for (int i = 0; i < 100; i++)
            {
                if (pg.InvokeRequired)
                    pg.Invoke(new ThreadStart(() =>
                        {
                            pg.PerformStep();
                        }));
                else
                    pg.PerformStep();
            }
        })).Start();
