            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.2); // customize update interval
            timer.Tick += delegate(object sender, EventArgs e)
            {
                StopwatchTime = sw.Elapsed.Seconds.ToString(); // customize format
            };
            timer.Start();
