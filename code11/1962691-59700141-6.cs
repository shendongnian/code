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
                // Lets pretend that something went wrong up above..
                throw new ArgumentNullException("Lets use this exception");
            });
            // Task that was running on the Worker Thread has completed
            // we return the List<string>
            return returnList;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // What if something went wrong we want to catch the exception...
            // the previous verion doesn;t let us do that...
            try
            {
                var t = await GetInformationAsync();
                // No exception was thrown
                foreach (string s in t)
                    listBox1.Items.Add(s);
            }
            catch
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Something went wrong!");
            }
        }
