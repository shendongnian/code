    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
      long ticks1 = 0;
      long ticks2 = 0;
      double interval = (double)Stopwatch.Frequency / 60;
      while (true) {
        ticks2 = Stopwatch.GetTimestamp();
        if (ticks2 >= ticks1 + interval) {
          ticks1 = Stopwatch.GetTimestamp();
          if(_fadeIn){
            _fadeAlpha += 0.1f;
            if(_fadeAlpha > 1f){
              _fadeAlpha = 1f;
              break;
            }
          }else{
            _fadeAlpha -= 0.1f;
            if(_fadeAlpha < 0f){
              _fadeAlpha = 0f;
              break;
            }
          }
          backgroundWorker.ReportProgress(0);
        }
        Thread.Sleep(1);
      }
      backgroundWorker.ReportProgress(0);
    }
