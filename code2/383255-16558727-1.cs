            void WriteProgress(string fileName)
        {
            progressBar.Visible = true;
            lblResizeProgressAmount.Visible = true;
            lblResizeProgress.Visible = true;
            progressBar.Value += 1;
            Interlocked.Increment(ref counter);
            lblResizeProgressAmount.Text = counter.ToString();
            
            ListViewItem lvi = new ListViewItem(fileName);
            listView1.Items.Add(lvi);
            listView1.FullRowSelect = true;
        }
        private void SignalCompletion(Stopwatch sw)
        {
            sw.Stop();
            
            if (tokenSource.IsCancellationRequested)
            {
                InitializeFields();
                lblFinished.Visible = true;
                lblFinished.Text = String.Format("Processing was cancelled after {0}", sw.Elapsed.ToString());
            }
            else
            {
                lblFinished.Visible = true;
                if (counter > 0)
                {
                    lblFinished.Text = String.Format("Resized {0} images in {1}", counter, sw.Elapsed.ToString());
                }
                else
                {
                    lblFinished.Text = "Nothing to resize";
                }
            }
        }
