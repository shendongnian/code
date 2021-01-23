        public Task<string> DownloadDataInBackground(int id)
        {
            TaskCompletionSource<string> resultTaskCompletionSource = new TaskCompletionSource<string>(id);
            WebClient client = new WebClient();
                
            Uri uri = new Uri(string.Format("https://www.google.com/search?q={0}", id));
            client.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    resultTaskCompletionSource.SetException(e.Error);
                else if (e.Cancelled)
                    resultTaskCompletionSource.SetCanceled();
                else
                    resultTaskCompletionSource.SetResult(e.Result);
            };
            client.DownloadStringAsync(uri);
            return resultTaskCompletionSource.Task;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int callid = rand++;
            Debug.WriteLine("Executing CallID #{0}", callid);
            
            DownloadDataInBackground(callid).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.WriteLine("Download for {0} completed with a length of {1}", task.AsyncState, task.Result.Length);
                }
            });
        }
