    IEnumerable<Task<Tuple<Uri, string>> tasks = urls.Select(url => {
        // Create the task completion source.
        var tcs = new TaskCompletionSource<Tuple<Uri, string>>();
        // The web client.
        var wc = new WebClient();
        // Attach to the DownloadStringCompleted event.
        client.DownloadStringCompleted += (s, e) => {
            // Dispose of the client when done.
            using (wc)
            {
                // If there is an error, set it.
                if (e.Error != null) 
                {
                    tcs.SetException(e.Error);
                }
                // Otherwise, set cancelled if cancelled.
                else if (e.Cancelled) 
                {
                    tcs.SetCanceled();
                }
                else 
                {
                    // Set the result.
                    tcs.SetResult(new Tuple<string, string>(url, e.Result));
                }
            }
        };
        // Start the process asynchronously, don't burn a thread.
        wc.DownloadStringAsync(url);
        // Return the task.
        return tcs.Task;
    });
