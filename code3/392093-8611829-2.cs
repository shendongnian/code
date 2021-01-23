            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // customize update interval
            timer.Tick += delegate (object sender, EventArgs e)
            {
                myTextBlock.Dispatcher.BeginInvoke(new Action(() =>
                {
                    myTextBlock.Text = myStopWatch.Elapsed.Seconds.ToString(); // customize format
                }));
            };
            timer.Start();
