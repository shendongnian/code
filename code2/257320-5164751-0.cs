        private int currItem;
        private void StartButton_Click(object sender, EventArgs e)
        {            
            if (SequenceListBox.Items.Count <= 0)
            {
                MessageBox.Show("Please select an Item");
                return;
            }
            // Prevent starting again
            StartButton.Enabled = false;
            // Must start stopwatch before timer to prevent timer_Elapsed from closing a non-existent stopwatch
            stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            // Start timer
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // If all item process, stop timer, stopwatch and re-enable button
            if (currItem >= SequenceListBox.Items.Count)
            {
                timer.Stop();
                stopwatch.Stop();
                timerLabel.Visible = true;
                timerLabel.Text = stopwatch.Elapsed.TotalSeconds.ToString("0" + " sec");
                stopwatch = null;
                MessageBox.Show("The Test is Finish");
                StartButton.Enabled = true;
            }
            else
            {
                // Select item and run it
                ElementControl item = SequenceListBox.Items[curItem];
                item.RunElement();
                currItem++;
                // Update progress bar
                progressBar1.Maximum = SequenceListBox.Items.Count;
                progressBar1.Value = currItem;
            }
        }
