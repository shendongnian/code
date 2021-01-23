    public class MyAsyncHandler : IHttpAsyncHandler
    {
        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            // NOTE: the result of this operation is void, but TCS requires some data type so we just use bool
            TaskCompletionSource<bool> webClientDownloadCompletionSource = new TaskCompletionSource<bool>();
            WebClient webClient = new WebClient())
            HttpContext currentHttpContext = HttpContext.Current;
            // Setup the download completed event handler
            client.DownloadDataCompleted += (o, e) =>
            {
                if(e.Cancelled)
                {
                    // If it was canceled, signal the TCS is cacnceled
                    // NOTE: probably don't need this since you have nothing canceling the operation anyway
                    webClientDownloadCompletionSource.SetCanceled();
                }
                else if(e.Error != null)
                {
                    // If there was an exception, signal the TCS with the exception
                    webClientDownloadCompletionSource.SetException(e.Error);
                }
                else
                {
                    // Success, write the response
                    currentHttpContext.Response.ContentType = "text/xml";
                    currentHttpContext.Response.OutputStream.Write(e.Result, 0, e.Result.Length);
                    // Signal the TCS that were done (we don't actually look at the bool result, but it's needed)
                    taskCompletionSource.SetResult(true);
                }
            };
            string url = "url_web_service_url";
            // Kick off the download immediately
            client.DownloadDataAsync(new Uri(url));
            // Get the TCS's task so that we can append some continuations
            Task webClientDownloadTask = webClientDownloadCompletionSource.Task;
            // Always dispose of the client once the work is completed
            webClientDownloadTask.ContinueWith(
                _ =>
                {
                    client.Dispose();
                },
                TaskContinuationOptions.ExecuteSynchronously);
            
            // If there was a callback passed in, we need to invoke it after the download work has completed
            if(cb != null)
            {
                webClientDownloadTask.ContinueWith(
                   webClientDownloadAntecedent =>
                   {
                       cb(webClientDownloadAntecedent);
                   },
                   TaskContinuationOptions.ExecuteSynchronously);
             }
            // Return the TCS's Task as the IAsyncResult
            return webClientDownloadTask;
        }
        public void EndProcessRequest(IAsyncResult result)
        {
            // Unwrap the task and wait on it which will propagate any exceptions that might have occurred
            ((Task)result).Wait();
        }
        public bool IsReusable
        {
            get 
            { 
                return true; // why not return true here? you have no state, it's easily reusable!
            }
        }
        public void ProcessRequest(HttpContext context)
        {
        }
    }
