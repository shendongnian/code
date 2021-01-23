     /// <summary>Downloads the resource with the specified URI as a byte array, asynchronously.</summary> 
        /// <param name="webClient">The WebClient.</param> 
        /// <param name="address">The URI from which to download data.</param> 
        /// <returns>A Task that contains the downloaded data.</returns> 
        public static Task<byte[]> DownloadDataTask(this WebClient webClient, string address) 
        { 
            return DownloadDataTask(webClient, new Uri(address)); 
        } 
 
        /// <summary>Downloads the resource with the specified URI as a byte array, asynchronously.</summary> 
        /// <param name="webClient">The WebClient.</param> 
        /// <param name="address">The URI from which to download data.</param> 
        /// <returns>A Task that contains the downloaded data.</returns> 
        public static Task<byte[]> DownloadDataTask(this WebClient webClient, Uri address) 
        { 
            // Create the task to be returned 
            var tcs = new TaskCompletionSource<byte[]>(address); 
 
            // Setup the callback event handler 
            DownloadDataCompletedEventHandler handler = null; 
            handler = (sender, e) => EAPCommon.HandleCompletion(tcs, e, () => e.Result, () => webClient.DownloadDataCompleted -= handler); 
            webClient.DownloadDataCompleted += handler; 
 
            // Start the async work 
            try 
            { 
                webClient.DownloadDataAsync(address, tcs); 
            } 
            catch(Exception exc) 
            { 
                // If something goes wrong kicking off the async work, 
                // unregister the callback and cancel the created task 
                webClient.DownloadDataCompleted -= handler; 
                tcs.TrySetException(exc); 
            } 
 
            // Return the task that represents the async operation 
            return tcs.Task; 
        }
