     DateTime beginTime = DateTime.Now;
     DispatcherTimer Timer = new DispatcherTimer()
     {
          Interval = TimeSpan.FromSeconds(1)
     };
     Timer.Tick += (s, e) =>
     {
          double elapsedTime = DateTime.Now.Substract(beginTime).TotalSeconds;
          ElapsedTime.Text = elapsedTime.ToString();
          if (elapsedTime > 120)
          {
               //Stop recording
               Timer.Stop();
          }
     }
     Timer.Start();
