        private int currItem;
        private List<ElementControl> Elements = new List<ElementControl>();
        private void StartButton_Click(object sender, EventArgs e)
        {            
            if (SequenceListBox.Items.Count <= 0)
            {
                MessageBox.Show("Please select an Item");
                return;
            }
            // Prevent starting again
            StartButton.Enabled = false;
            Elements.Clear();
            foreach (ElementControl ele in SequenceListBox.Items)
                Elements.Add(ele);
            // Must start stopwatch before timer to prevent timer_Elapsed from closing a non-existent stopwatch
            stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            // Start timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        public delegate void ReportProgressHandler(int value, string text);
        private void ReportProgress(int value, string text)
        {
            if (InvokeRequired)
                Invoke(new ReportProgressHandler(ReportProgress), value, text);
            else
            {
                if(value <= progressBar1.Maximum)
                    progressBar1.Value = value;
                timerLabel.Text = text;
            }
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // If all item process, stop timer, stopwatch and re-enable button
            if (currItem >= Elements.Count)
            {
                timer.Stop();
                stopwatch.Stop();
                ReportProgress (curItem, stopwatch.Elapsed.TotalSeconds.ToString("0" + " sec"));
                stopwatch = null;
                MessageBox.Show("The Test is Finish");
                //StartButton.Enabled = true;
                // Use the same approach as that used to report progress.
            }
            else
            {
                // Select item and run it
                ElementControl item = Elements[curItem];
                item.RunElement();
                currItem++;
                ReportProgress (curItem, "sometext"));
            }
        }
