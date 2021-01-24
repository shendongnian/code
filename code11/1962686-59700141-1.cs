        private async Task<List<string>> GetInformationAsync()
        {
            var returnList = new List<string>();
            Stopwatch sw = new Stopwatch();
            // The UI thread will free up at this point, no "real" work has
            // started so it won;t have hung
            await Task.Run(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    returnList.Add($"Item# {i}");
                    // Simulate 10 seconds of CPU load on a worker thread
                    sw.Restart();
                    while (sw.Elapsed < TimeSpan.FromSeconds(2))
                        ; /* WARNING 100% CPU for this worker thread for 2 seconds */
                }
            });
            // Task that was running on the Worker Thread has completed
            // we return the List<string>
            return returnList;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // Get some information and put this into the listBox
            var t = await GetInformationAsync();
            // The CPU intensive task has completed we now have a list of items
            // This will run on the UI thread, as evidenced by no Cross Thread exception
            foreach (string s in t)
                listBox1.Items.Add(s);
        }
