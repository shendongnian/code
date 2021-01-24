        private async Task<List<string>> GetInformationAsync(IProgress<int> progress)
        {
            var returnList = new List<string>();
            Stopwatch sw = new Stopwatch();
            // The UI thread will free up at this point, no "real" work has
            // started so it won;t have hung
            await Task.Run(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    // Simulate 10 seconds of CPU load on a worker thread
                    sw.Restart();
                    while (sw.Elapsed < TimeSpan.FromSeconds(2))
                        ; /* WARNING 100% CPU for this worker thread for 2 seconds */
                    returnList.Add($"Item# {i}");
                    // Report back to the UI thread
                    // increases the progress bar...
                    progress.Report((i+1)*10);
                }
            });
            // Task that was running on the Worker Thread has completed
            // we return the List<string>
            return returnList;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                var progress = new Progress<int>(i => progressBar1.Value = i);
                var t = await GetInformationAsync(progress);
                // No exeception was thrown
                foreach (string s in t)
                    listBox1.Items.Add(s);
            }
            catch
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Something went wrong!");
            }
            finally
            {
                button1.Enabled = true;
            }
        }
