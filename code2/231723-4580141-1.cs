    var pBars = new[] { progressBar1, progressBar2, progressBar3, progressBar4 };
    foreach (var pBar in pBars)
    {
        new Thread(currentPBar => 
        {
            for (double x = 0; x < 10000; x = x + 0.5)
            {             
                var progress = (int)x;
                Action<ProgressBar, int> del = UpdateProgress;
                Invoke(
                    del, 
                    new object[] { (ProgressBar)currentPBar, progress }
                );
                Thread.Sleep(2);
            }            
        }).Start(pBar);
    }
