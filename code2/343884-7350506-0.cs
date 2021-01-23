    public static class Extensions  
    {
        public static Task<XDocument> GetRssDownloadTask(
            this WebClient client, Uri rssFeedUri)
        {
            // task completion source is an object, which has some state.
            // it gives out the task, which completes, when state turns "completed"
            // or else it could be canceled or throw an exception
            var tcs = new TaskCompletionSource<XDocument>(); 
            // now we subscribe to completed event. depending on event result
            // we set TaskCompletionSource state completed, canceled, or error
            client.DownloadStringCompleted += (sender, e) => {
	            if(e.Cancelled) tcs.SetCanceled();
	            if(null != e.Error) tcs.SetException(e.Error);
				
	            tcs.SetResult(XDocument.Parse(e.Result));
            };
            // now we start asyncronous operation
            client.DownloadStringAsync(rssFeedUri);
            // and return the underlying task immideately
            return tcs.Task;
        }
    }
